using MediatR;

namespace FutManagement.Application.Features.Clubs.Commands.DeleteClub;

public record DeleteClubCommand(Guid Id) : IRequest<bool>;
