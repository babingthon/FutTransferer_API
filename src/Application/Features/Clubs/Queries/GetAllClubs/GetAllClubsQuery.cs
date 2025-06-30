using FutManagement.Application.Features.Clubs.Queries.Shared;
using MediatR;

namespace FutManagement.Application.Features.Clubs.Queries.Queries.GetAllClubs;

public record GetAllClubsQuery(string? CountryCode) : IRequest<IEnumerable<ClubResponse>>;