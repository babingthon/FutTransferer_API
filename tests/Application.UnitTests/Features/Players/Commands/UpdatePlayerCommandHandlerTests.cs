using FluentAssertions;
using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Players.Commands.UpdatePlayer;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using FutManagement.Core.Enums;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Players.Commands;

public class UpdatePlayerCommandHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly UpdatePlayerCommandHandler _handler;

    public UpdatePlayerCommandHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new UpdatePlayerCommandHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_Should_UpdatePlayer_WhenPlayerExists()
    {
        var playerId = Guid.NewGuid();
        var clubId = Guid.NewGuid();
        var nationalityId = Guid.NewGuid();

        var existingPlayer = new Player
        {
            Id = playerId,
            FullName = "Old Name",
            Position = Position.Midfielder,
            MarketValue = 1000,
            ClubId = clubId,
            NationalityId = nationalityId
        };
        
        var players = new List<Player> { existingPlayer };
        var mockPlayerDbSet = players.AsQueryable().BuildMockDbSet();
        
        _mockDbContext.Setup(x => x.Players).Returns(mockPlayerDbSet.Object);
        _mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var command = new UpdatePlayerCommand(
            playerId,
            "Lionel Messi",
            "La Pulga",
            new DateTime(1987, 6, 24),
            Position.Forward,
            150000000,
            MedicalStatus.Fit,
            PlayerStatus.Active,
            nationalityId,
            clubId
        );
    
        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeTrue();
        existingPlayer.FullName.Should().Be("Lionel Messi");
        existingPlayer.Nickname.Should().Be("La Pulga");
        existingPlayer.Position.Should().Be(Position.Forward);
        _mockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenPlayerDoesNotExist()
    {
        var nonExistentPlayerId = Guid.NewGuid();
        var players = new List<Player>();
        var mockPlayerDbSet = players.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Players).Returns(mockPlayerDbSet.Object);

        var command = new UpdatePlayerCommand(
            nonExistentPlayerId, "Any Name", null, DateTime.Now, Position.Defender, 
            0, MedicalStatus.Fit, PlayerStatus.Active, Guid.NewGuid(), Guid.NewGuid());

        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);
   
        await action.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Player with ID {nonExistentPlayerId} was not found.");
    }
}