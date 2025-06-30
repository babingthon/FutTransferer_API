using FluentValidation.TestHelper;
using FutManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Interfaces.Persistence;

public interface IAppDbContext
{
    DbSet<Player> Players { get; }
    DbSet<Club> Clubs { get; }
    DbSet<Country> Countries { get; }
    DbSet<Transfer> Transfers { get; }
    DbSet<PaymentInstallment> PaymentInstallments { get; }
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}