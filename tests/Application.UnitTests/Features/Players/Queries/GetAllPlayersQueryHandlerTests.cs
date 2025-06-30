using FluentAssertions;
using FutManagement.Application.Features.Players.Queries.GetAllPlayers;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Players.Queries;

public class GetAllPlayersQueryHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly GetAllPlayersQueryHandler _handler;
    private readonly List<Player> _players;
    private readonly Country _brazil;
    private readonly Country _portugal;
    private readonly Club _clubA;
    private readonly Club _clubB;

    public GetAllPlayersQueryHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new GetAllPlayersQueryHandler(_mockDbContext.Object);

        _brazil = new Country { Id = Guid.NewGuid(), Name = "Brazil", Code = "BRA" };
        _portugal = new Country { Id = Guid.NewGuid(), Name = "Portugal", Code = "POR" };
        _clubA = new Club { Id = Guid.NewGuid(), Name = "Club A" };
        _clubB = new Club { Id = Guid.NewGuid(), Name = "Club B" };

        _players = new List<Player>
        {
            new() { Id = Guid.NewGuid(), FullName = "Player A", NationalityId = _brazil.Id, Nationality = _brazil, ClubId = _clubA.Id, Club = _clubA },
            new() { Id = Guid.NewGuid(), FullName = "Player B", NationalityId = _brazil.Id, Nationality = _brazil, ClubId = _clubB.Id, Club = _clubB },
            new() { Id = Guid.NewGuid(), FullName = "Player C", NationalityId = _portugal.Id, Nationality = _portugal, ClubId = _clubA.Id, Club = _clubA }
        };

        var mockPlayerDbSet = _players.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Players).Returns(mockPlayerDbSet.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnPaginatedResponse_WhenNoFilterIsProvided()
    {
        var query = new GetAllPlayersQuery(1, 2, null, null);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.PageNumber.Should().Be(1);
        result.PageSize.Should().Be(2);
        result.TotalRecords.Should().Be(3); 
        result.TotalPages.Should().Be(2); 
        result.Data.Should().HaveCount(2);  
    }

    [Fact]
    public async Task Handle_Should_ReturnFilteredPlayers_WhenClubIdIsProvided()
    {
        var query = new GetAllPlayersQuery(1, 10, null, _clubA.Id);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.TotalRecords.Should().Be(2);
        result.Data.Should().HaveCount(2);
        result.Data.Should().OnlyContain(p => p.ClubName == "Club A");
    }

    [Fact]
    public async Task Handle_Should_ReturnFilteredPlayers_WhenCountryCodeIsProvided()
    {
        var query = new GetAllPlayersQuery(1, 10, "BRA", null);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.TotalRecords.Should().Be(2);
        result.Data.Should().HaveCount(2);
        result.Data.Should().OnlyContain(p => p.NationatilyName == "Brazil");
    }
}