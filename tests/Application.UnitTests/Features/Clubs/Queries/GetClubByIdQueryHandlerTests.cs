using FluentAssertions;
using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Clubs.Queries.Queries.GetClubById;
using FutManagement.Application.Features.Clubs.Queries.Shared;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MockQueryable.Moq;
using Moq;

namespace FutManagement.Application.UnitTests.Features.Clubs.Queries;

public class GetClubByIdQueryHandlerTests
{
    private readonly Mock<IAppDbContext> _mockDbContext;
    private readonly GetClubByIdQueryHandler _handler;

    public GetClubByIdQueryHandlerTests()
    {
        _mockDbContext = new Mock<IAppDbContext>();
        _handler = new GetClubByIdQueryHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnClubResponse_WhenClubExists()
    {
        var clubId = Guid.NewGuid();
        var country = new Country
        {
            Id = Guid.NewGuid(),
            Name = "Brazil",
            Code = "BRA"
        };
        var clubs = new List<Club>
        {
            new Club()
            {
                Id = clubId,
                Name = "Flamengo",
                CountryId = country.Id,
                Country = country,
                FoundingYear = 1895,
                TransferBudget = 50000000
            }
        };
        var mockClubDbSet = clubs.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);
        
        var query = new GetClubByIdQuery(clubId);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Should().BeOfType<ClubResponse>();
        result!.Name.Should().Be("Flamengo");
        result.CountryName.Should().Be("Brazil");
    }
    
    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenClubDoesNotExist() // Nome do teste atualizado
    {
        var nonExistentClubId = Guid.NewGuid();
        var clubs = new List<Club>(); 
        var mockClubDbSet = clubs.AsQueryable().BuildMockDbSet();
        _mockDbContext.Setup(x => x.Clubs).Returns(mockClubDbSet.Object);

        var query = new GetClubByIdQuery(nonExistentClubId);

        Func<Task> action = async () => await _handler.Handle(query, CancellationToken.None);

        await action.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Club with ID {nonExistentClubId} was not found.");
    }
}