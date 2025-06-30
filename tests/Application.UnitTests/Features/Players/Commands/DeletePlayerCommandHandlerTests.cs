using FluentAssertions;
using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Players.Commands.DeletePlayer;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Players.Commands;

public class DeletePlayerCommandHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly DeletePlayerCommandHandler _handler;

    public DeletePlayerCommandHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new DeletePlayerCommandHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_Should_RemovePlayer_WhenPlayerExists()
    {
        var playerId = Guid.NewGuid();
        var existingPlayer = new Player { Id = playerId, FullName = "Cristiano Ronaldo" };
        var players = new List<Player> { existingPlayer };
        
        var mockPlayerDbSet = players.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Players).Returns(mockPlayerDbSet.Object);
        _mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var command = new DeletePlayerCommand(playerId);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeTrue();

        _mockDbContext.Verify(x => x.Players.Remove(existingPlayer), Times.Once);
        _mockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenPlayerDoesNotExist()
    {
        var nonExistentPlayerId = Guid.NewGuid();
        var players = new List<Player>();
        var mockPlayerDbSet = players.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Players).Returns(mockPlayerDbSet.Object);

        var command = new DeletePlayerCommand(nonExistentPlayerId);

        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);

        await action.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Player with ID {nonExistentPlayerId} was not found.");
    }
}