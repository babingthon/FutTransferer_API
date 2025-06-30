using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MediatR;

namespace FutManagement.Application.Features.Clubs.Commands.CreateClub;

public class CreateClubCommandHandler : IRequestHandler<CreateClubCommand, Guid>
{
    private readonly IAppDbContext _context;

    public CreateClubCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateClubCommand request, CancellationToken cancellationToken)
    {
        var club = new Club
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CountryId = request.CountryId,
            FoundingYear = request.FoundingYear,
            TransferBudget = request.TransferBudget,
            CreatedAt = DateTime.UtcNow
        };
        
        await _context.Clubs.AddAsync(club, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return club.Id;
    }
}