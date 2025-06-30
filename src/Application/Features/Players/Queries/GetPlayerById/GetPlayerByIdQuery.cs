using FutManagement.Application.Features.Players.Queries.Shared;
using MediatR;

namespace FutManagement.Application.Features.Players.Queries.GetPlayerById;

public record GetPlayerByIdQuery(Guid Id) : IRequest<PlayerResponse?>;