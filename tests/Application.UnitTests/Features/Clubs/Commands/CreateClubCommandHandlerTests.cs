using FluentAssertions;
using FutManagement.Application.Features.Clubs.Commands.CreateClub;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Clubs.Commands;

public class CreateClubCommandHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly CreateClubCommandHandler _handler;

    public CreateClubCommandHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new CreateClubCommandHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_Should_AddNewClubToDbContext_AndReturnItsId()
    {
        var clubsList = new List<Club>();
        _mockDbContext.Setup(x => x.Clubs.AddAsync(It.IsAny<Club>(), It.IsAny<CancellationToken>()))
            .Callback<Club, CancellationToken>((club, token) => clubsList.Add(club));

        _mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var command = new CreateClubCommand(
            "Paris Saint-Germain",
            Guid.NewGuid(),
            1970,
            200000000
        );

        var newClubId = await _handler.Handle(command, CancellationToken.None);

        newClubId.Should().NotBeEmpty();

        clubsList.Should().HaveCount(1);

        var addedClub = clubsList[0];
        addedClub.Id.Should().Be(newClubId);
        addedClub.Name.Should().Be("Paris Saint-Germain");
        addedClub.FoundingYear.Should().Be(1970);

        _mockDbContext.Verify(x => x.Clubs.AddAsync(It.IsAny<Club>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockDbContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}