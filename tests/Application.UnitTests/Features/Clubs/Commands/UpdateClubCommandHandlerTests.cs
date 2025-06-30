using FluentAssertions;
using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Clubs.Commands.UpdateClub;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Clubs.Commands;

public class UpdateClubCommandHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly UpdateClubCommandHandler _handler;

    public UpdateClubCommandHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new UpdateClubCommandHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_Should_UpdateClub_WhenClubExists()
    {
        var countryId = Guid.NewGuid();
        var clubId = Guid.NewGuid();

        var existingClub = new Club
        {
            Id = clubId,
            Name = "Old Name",
            CountryId = countryId,
            FoundingYear = 1900,
            TransferBudget = 1000000
        };
        var clubs = new List<Club> { existingClub };
        var mockClubDbSet = clubs.AsQueryable().BuildMockDbSet();
        
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);
        _mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var command = new UpdateClubCommand(
            clubId,
            "New Updated Name",
            countryId,
            1905,
            5000000
        );

        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().BeTrue();
        existingClub.Name.Should().Be("New Updated Name");
        existingClub.FoundingYear.Should().Be(1905);
        _mockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenClubDoesNotExist()
    {
        var nonExistentClubId = Guid.NewGuid();

        var clubs = new List<Club>();
        var mockClubDbSet = clubs.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);

        var command = new UpdateClubCommand(
            nonExistentClubId,
            "Any Name",
            Guid.NewGuid(),
            2000,
            1000
        );

        Func<Task> action = async () => await _handler.Handle(command, CancellationToken.None);

        await action.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Club with ID {nonExistentClubId} was not found.");
    }
}