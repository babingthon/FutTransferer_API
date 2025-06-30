using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Players.Queries.Shared;
using FutManagement.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Players.Queries.GetPlayerById;

public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, PlayerResponse?>
{
    private readonly IAppDbContext _context;

    public GetPlayerByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<PlayerResponse?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var player = await _context.Players
            .AsNoTracking()
            .Include(p => p.Nationality)
            .Include(p => p.Club)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        if (player is null)
        {
            throw new NotFoundException($"Player with ID {request.Id} was not found.");
        }
        
        return new PlayerResponse(
            player.Id,
            player.FullName,
            player.Nickname,
            player.Age,
            player.Position.ToString(),
            player.MarketValue,
            player.MedicalStatus.ToString(),
            player.PlayerStatus.ToString(),
            player.Nationality.Name,
            player.Club?.Name
        );
    }
}