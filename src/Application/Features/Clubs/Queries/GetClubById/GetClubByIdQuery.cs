using FutManagement.Application.Features.Clubs.Queries.Shared;
using MediatR;

namespace FutManagement.Application.Features.Clubs.Queries.Queries.GetClubById;

public record GetClubByIdQuery(Guid Id) : IRequest<ClubResponse?>;