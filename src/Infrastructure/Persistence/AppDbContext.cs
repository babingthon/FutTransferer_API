using System.Reflection;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using FutManagement.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Country> Countries { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Transfer> Transfers { get; set; }
    
    public DbSet<PaymentInstallment> PaymentInstallments { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.Entity<Country>()
            .HasMany(c => c.Players)
            .WithOne(p => p.Nationality)
            .HasForeignKey(p => p.NationalityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Country>()
            .HasMany(c => c.Clubs)
            .WithOne(c => c.Country)
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Country>().ToTable("countries");
        
        modelBuilder.Entity<Club>()
            .HasMany(c => c.Players)
            .WithOne(p => p.Club)
            .HasForeignKey(p => p.ClubId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Club>().ToTable("clubs");
        
        modelBuilder.Entity<Player>()
            .Property(p => p.Position)
            .HasConversion<string>();
        
        modelBuilder.Entity<Player>()
            .Property(p => p.MedicalStatus)
            .HasConversion<string>();
        
        modelBuilder.Entity<Player>()
            .Property(p => p.PlayerStatus)
            .HasConversion<string>();
        
        modelBuilder.Entity<Player>().ToTable("players");
        
        modelBuilder.Entity<Transfer>(entity =>
        {
            entity.ToTable("transfers");

            entity.HasOne(t => t.Player)
                .WithMany() 
                .HasForeignKey(t => t.PlayerId)
                .OnDelete(DeleteBehavior.Restrict); 

            entity.HasOne(t => t.OriginClub)
                .WithMany() 
                .HasForeignKey(t => t.OriginClubId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.DestinationClub)
                .WithMany() 
                .HasForeignKey(t => t.DestinationClubId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(t => t.Status).HasConversion<string>();
            entity.Property(t => t.Type).HasConversion<string>();
            entity.Property(t => t.PaymentType).HasConversion<string>();
        });
        
        modelBuilder.Entity<PaymentInstallment>(entity =>
        {
            entity.ToTable("payment_installments");

            entity.HasOne(p => p.Transfer)
                .WithMany(t => t.Installments)
                .HasForeignKey(p => p.TransferId)
                .OnDelete(DeleteBehavior.Cascade); 
        });
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.Role).HasConversion<string>();
        });

        modelBuilder.SeedCountries();
        modelBuilder.SeedClubs();
        modelBuilder.SeedUsers();
    }
}