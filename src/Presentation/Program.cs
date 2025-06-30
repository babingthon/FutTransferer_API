using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using AspNetCore.Scalar;
using FluentValidation;
using FutManagement.Application.Common.Behaviors;
using FutManagement.Application.Interfaces.Authentication;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Application.Interfaces.Services;
using FutManagement.Infrastructure.Authentication;
using FutManagement.Infrastructure.Persistence;
using FutManagement.Infrastructure.Services;
using FutManagement.Presentation.Middleware;
using Hangfire;
using Hangfire.PostgreSql;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using Serilog;

DotNetEnv.Env.Load();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up the application");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());

    #region Database & Persistence Configuration

    var dbHost = builder.Configuration["ConnectionStrings:Host"] ?? "localhost";
    var dbPort = builder.Configuration["ConnectionStrings:Port"] ?? "5432";
    var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
    var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
    var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

    if (string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(dbUser) || string.IsNullOrEmpty(dbPassword))
    {
        throw new InvalidOperationException("Database credentials are not configured in .env file.");
    }

    var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

    builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

    #endregion

    #region Authentication & Authorization Configuration

    var jwtSettings = new JwtSettings();
    builder.Configuration.Bind(JwtSettings.SectionName, jwtSettings);
    var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
    if (string.IsNullOrEmpty(jwtSecret))
    {
        throw new InvalidOperationException("JWT Secret is not configured in the .env file or as an environment variable.");
    }
    jwtSettings.Secret = jwtSecret;

    builder.Services.AddSingleton(Options.Create(jwtSettings));
    builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

    builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        });

    builder.Services.AddAuthorization();

    #endregion

    #region Application Services Configuration

    builder.Services.AddMediatR(cfg => 
        cfg.RegisterServicesFromAssembly(typeof(FutManagement.Application.AssemblyReference).Assembly));
    builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    builder.Services.AddValidatorsFromAssembly(typeof(FutManagement.Application.AssemblyReference).Assembly);
    
    builder.Services.AddMemoryCache();
    builder.Services.AddTransient<IEmailService, EmailService>();
    
    builder.Services.AddHangfire(config => config
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UsePostgreSqlStorage(options => options.UseNpgsqlConnection(connectionString)));
    builder.Services.AddHangfireServer(options => options.WorkerCount = 1);

    #endregion

    #region Presentation Layer Configuration

    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new() { Title = "FutManagement API", Version = "v1" });
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                Array.Empty<string>()
            }
        });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

    builder.Services.AddTransient<GlobalExceptionHandler>();

    #endregion

    var app = builder.Build();
    
    #region Apply Migrations on Startup

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var dbContext = services.GetRequiredService<AppDbContext>();

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                Log.Information("Applying database migrations...");
                await dbContext.Database.MigrateAsync();
                Log.Information("Database migrations applied successfully.");
            }
            else
            {
                Log.Information("Database is up to date. No migrations to apply.");
            }
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "An error occurred while applying database migrations.");
        }
    }

    #endregion

    app.UseMiddleware<GlobalExceptionHandler>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.MapScalarApiReference();
        app.UseScalar(options =>

        {
            options.UseTheme(Theme.Default);
            options.RoutePrefix = "api-docs";
        });
        
        app.UseHangfireDashboard("/hangfire");
    }

    app.UseHttpsRedirection();
    
    app.UseSerilogRequestLogging();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}