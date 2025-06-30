using MediatR;

namespace FutManagement.Application.Features.Transfers.Commands.FinalizeTransfer;

public record FinalizeTransferCommand(Guid TransferId) : IRequest<bool>; 