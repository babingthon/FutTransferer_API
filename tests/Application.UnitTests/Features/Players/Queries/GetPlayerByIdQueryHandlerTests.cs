using FluentAssertions;
using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Players.Queries.GetPlayerById;
using FutManagement.Application.Features.Players.Queries.Shared;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using FutManagement.Core.Enums;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Players.Queries;

public class GetPlayerByIdQueryHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly GetPlayerByIdQueryHandler _handler;

    public GetPlayerByIdQueryHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new GetPlayerByIdQueryHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnPlayerResponse_WhenPlayerExists()
    {
        var playerId = Guid.NewGuid();
        var country = new Country { Id = Guid.NewGuid(), Name = "Portugal", Code = "POR" };
        var club = new Club { Id = Guid.NewGuid(), Name = "Al-Nassr" };
        
        var players = new List<Player>
        {
            new()
            {
                Id = playerId,
                FullName = "Cristiano Ronaldo",
                Nickname = "CR7",
                DateOfBirth = new DateTime(1985, 2, 5),
                Position = Position.Forward,
                MarketValue = 20000000,
                MedicalStatus = MedicalStatus.Fit,
                PlayerStatus = PlayerStatus.Active,
                NationalityId = country.Id,
                Nationality = country,
                ClubId = club.Id,
                Club = club 
            }
        };

        var mockPlayerDbSet = players.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Players).Returns(mockPlayerDbSet.Object);

        var query = new GetPlayerByIdQuery(playerId);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().BeOfType<PlayerResponse>();
        result!.FullName.Should().Be("Cristiano Ronaldo");
        result.NationatilyName.Should().Be("Portugal");
        result.ClubName.Should().Be("Al-Nassr");
    }
    
    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenPlayerDoesNotExist()
    {
        var nonExistentPlayerId = Guid.NewGuid();
        var players = new List<Player>();
        var mockPlayerDbSet = players.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Players).Returns(mockPlayerDbSet.Object);
    
        var query = new GetPlayerByIdQuery(nonExistentPlayerId);
 
        Func<Task> action = async () => await _handler.Handle(query, CancellationToken.None);
 
        await action.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Player with ID {nonExistentPlayerId} was not found.");
    }
}