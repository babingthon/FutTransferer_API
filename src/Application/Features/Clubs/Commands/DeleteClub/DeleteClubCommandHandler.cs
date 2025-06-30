using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Clubs.Commands.DeleteClub;

public class DeleteClubCommandHandler : IRequestHandler<DeleteClubCommand, bool>
{
    private readonly IAppDbContext _context;

    public DeleteClubCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteClubCommand request, CancellationToken cancellationToken)
    {
        var club = await _context.Clubs.FirstOrDefaultAsync(c=> c.Id == request.Id, cancellationToken);
        
        if (club is null)
        {
            throw new NotFoundException($"Club with ID {request.Id} was not found.");
        }
        
        _context.Clubs.Remove(club);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}