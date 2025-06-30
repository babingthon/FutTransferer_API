using FutManagement.Core.Enums;
using MediatR;

namespace FutManagement.Application.Features.Transfers.Commands.InitiateTransfer;

public record InitiateTransferCommand(
    Guid PlayerId,
    Guid OriginClubId,
    Guid DestinationClubId,
    decimal TransferValue,
    TransferType Type,
    PaymentType PaymentType,
    int NumberOfInstallments
    ) : IRequest<Guid>;