using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Players.Commands.DeletePlayer;

public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, bool>
{
    private readonly IAppDbContext _context;

    public DeletePlayerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (player is null)
        {
            throw new NotFoundException($"Player with ID {request.Id} was not found.");
        }

        _context.Players.Remove(player);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}