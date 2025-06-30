using System.Text.Json;
using FutManagement.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FutManagement.Presentation.Middleware;

public class GlobalExceptionHandler : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/problem+json";

        var problemDetails = exception switch
        {
            NotFoundException => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Not Found",
                Detail = exception.Message
            },

            BusinessRuleViolationException => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest, 
                Title = "Business Rule Violation",
                Detail = exception.Message
            },
            
            ValidationException validationEx => CreateValidationProblemDetails(validationEx),

            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Detail = "An unexpected error occurred. Please try again later."
            }
        };

        context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
    
        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }

    private static ProblemDetails CreateValidationProblemDetails(ValidationException exception)
    {
        var problem = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation Error",
            Detail = "One or more validation errors occurred."
        };
 
        problem.Extensions.Add("errors", exception.Errors);
        return problem;
    }
}