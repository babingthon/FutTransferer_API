using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Players.Commands.UpdatePlayer;

public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, bool>
{
    private readonly IAppDbContext _context;

    public UpdatePlayerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (player is null)
        {
            throw new NotFoundException($"Player with ID {request.Id} was not found.");
        }

        player.FullName = request.FullName;
        player.Nickname = request.NickName;
        player.DateOfBirth = request.DateOfBirth;
        player.Position = request.Position;
        player.MarketValue = request.MarketValue;
        player.MedicalStatus = request.MedicalStatus;
        player.PlayerStatus = request.PlayerStatus;
        player.NationalityId = request.NationalityId;
        player.ClubId = request.ClubId;
        player.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}