using FutManagement.Application.Common.Models;
using FutManagement.Application.Features.Players.Queries.Shared;
using MediatR;

namespace FutManagement.Application.Features.Players.Queries.GetAllPlayers;

public record GetAllPlayersQuery(
    int PageNumber,
    int PageSize,
    string? CountryCode,
    Guid? ClubId
    ) : IRequest<PagedResponse<PlayerResponse>>;