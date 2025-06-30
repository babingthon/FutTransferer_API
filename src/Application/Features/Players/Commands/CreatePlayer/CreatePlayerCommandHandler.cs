using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MediatR;

namespace FutManagement.Application.Features.Players.Commands.CreatePlayer;

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Guid>
{
    private readonly IAppDbContext _context;

    public CreatePlayerCommandHandler(IAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Player
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Nickname = request.NickName,
            DateOfBirth = request.DateOfBirth,
            Position = request.Position,
            MarketValue = request.MarketValue,
            MedicalStatus = request.MedicalStatus,
            PlayerStatus = request.PlayerStatus,
            NationalityId = request.NationalityId,
            ClubId = request.ClubId,
            CreatedAt = DateTime.UtcNow 
        };

        await _context.Players.AddAsync(player, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return player.Id;
    }
}