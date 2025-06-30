using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Clubs.Commands.UpdateClub;

public class UpdateClubCommandHandler : IRequestHandler<UpdateClubCommand, bool>
{
    private readonly IAppDbContext _context;

    public UpdateClubCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateClubCommand request, CancellationToken cancellationToken)
    {
        var club = await _context.Clubs.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (club is null)
        {
            throw new NotFoundException($"Club with ID {request.Id} was not found.");
        }
        
        club.Name = request.Name;
        club.CountryId = request.CountryId;
        club.FoundingYear = request.FoundingYear;
        club.TransferBudget = request.TransferBudget;
        club.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}