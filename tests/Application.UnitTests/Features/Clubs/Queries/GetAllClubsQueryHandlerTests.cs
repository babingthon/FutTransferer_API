using FluentAssertions;
using FutManagement.Application.Features.Clubs.Queries.Queries.GetAllClubs;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Clubs.Queries;

public class GetAllClubsQueryHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly GetAllClubsQueryHandler _handler;

    public GetAllClubsQueryHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        var mockLogger = new Mock<ILogger<GetAllClubsQueryHandler>>(); 
        var mockCache = new Mock<IMemoryCache>();
        _handler = new GetAllClubsQueryHandler(_mockDbContext.Object);
    }
    
        [Fact]
    public async Task Handle_Should_ReturnAllClubs_WhenNoFilterIsProvided()
    {
        var country1 = new Country { Id = Guid.NewGuid(), Name = "Brazil", Code = "BRA" };
        var country2 = new Country { Id = Guid.NewGuid(), Name = "England", Code = "ENG" };
        var clubs = new List<Club>
        {
            new() { Id = Guid.NewGuid(), Name = "Flamengo", Country = country1 },
            new() { Id = Guid.NewGuid(), Name = "Arsenal", Country = country2 }
        };

        var mockClubDbSet = clubs.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);

        var query = new GetAllClubsQuery(null);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task Handle_Should_ReturnFilteredClubs_WhenCountryCodeIsProvided()
    {
        var brazilId = Guid.NewGuid();
        var englandId = Guid.NewGuid();
        var country1 = new Country { Id = brazilId, Name = "Brazil", Code = "BRA" };
        var country2 = new Country { Id = englandId, Name = "England", Code = "ENG" };
        var clubs = new List<Club>
        {
            new() { Id = Guid.NewGuid(), Name = "Flamengo", CountryId = brazilId, Country = country1 },
            new() { Id = Guid.NewGuid(), Name = "Palmeiras", CountryId = brazilId, Country = country1 },
            new() { Id = Guid.NewGuid(), Name = "Arsenal", CountryId = englandId, Country = country2 }
        };

        var mockClubDbSet = clubs.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);

        var query = new GetAllClubsQuery("BRA");

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().OnlyContain(c => c.CountryName == "Brazil - BRA");
    }

    [Fact]
    public async Task Handle_Should_ReturnEmptyList_WhenNoClubsExist()
    {
        var clubs = new List<Club>();
        var mockClubDbSet = clubs.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);

        var query = new GetAllClubsQuery(null);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}