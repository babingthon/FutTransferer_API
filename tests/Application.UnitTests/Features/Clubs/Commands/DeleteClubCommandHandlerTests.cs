using FluentAssertions;
using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Clubs.Commands.DeleteClub;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Clubs.Commands;

public class DeleteClubCommandHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly DeleteClubCommandHandler _handler;

    public DeleteClubCommandHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new DeleteClubCommandHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_Should_RemoveClub_WhenClubExists()
    {
        var clubId = Guid.NewGuid();
        var existingClub = new Club { Id = clubId, Name = "Boca Juniors" };
        var clubs = new List<Club> { existingClub };
        
        var mockClubDbSet = clubs.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);
        _mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var command = new DeleteClubCommand(clubId);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeTrue();

        _mockDbContext.Verify(x => x.Clubs.Remove(existingClub), Times.Once);
        _mockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenClubDoesNotExist()
    {
        var nonExistentClubId = Guid.NewGuid();
        var clubs = new List<Club>();
        var mockClubDbSet = clubs.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);

        var command = new DeleteClubCommand(nonExistentClubId);

        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);

        await action.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Club with ID {nonExistentClubId} was not found.");
    }
}