using FluentAssertions;
using FutManagement.Application.Features.Players.Commands.CreatePlayer;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using FutManagement.Core.Enums;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Players.Commands;

public class CreatePlayerCommandHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly CreatePlayerCommandHandler _handler;

    public CreatePlayerCommandHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new CreatePlayerCommandHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_Should_AddPlayerToDbContext_AndReturnItsId()
    {
        var playersList = new List<Player>();
        _mockDbContext.Setup(x => x.Players.AddAsync(It.IsAny<Player>(), It.IsAny<CancellationToken>()))
            .Callback<Player, CancellationToken>((player, token) => playersList.Add(player));
            
        _mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var command = new CreatePlayerCommand(
            "Neymar Jr",
            "Ney",
            new DateTime(1992, 2, 5),
            Position.Forward,
            90000000,
            MedicalStatus.Fit,
            PlayerStatus.Active,
            Guid.NewGuid(),
            Guid.NewGuid() 
        );

        var newPlayerId = await _handler.Handle(command, CancellationToken.None);

        newPlayerId.Should().NotBeEmpty();
        
        playersList.Should().HaveCount(1);
        var addedPlayer = playersList[0];
        addedPlayer.Id.Should().Be(newPlayerId);
        addedPlayer.FullName.Should().Be("Neymar Jr");
        addedPlayer.Position.Should().Be(Position.Forward);
        
        _mockDbContext.Verify(x => x.Players.AddAsync(It.IsAny<Player>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}