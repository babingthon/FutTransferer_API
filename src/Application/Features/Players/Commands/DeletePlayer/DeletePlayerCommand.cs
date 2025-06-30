using MediatR;

namespace FutManagement.Application.Features.Players.Commands.DeletePlayer;

public record DeletePlayerCommand(Guid Id) : IRequest<bool>;