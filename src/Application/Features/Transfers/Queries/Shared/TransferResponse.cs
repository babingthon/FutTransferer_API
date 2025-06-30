namespace FutManagement.Application.Features.Transfers.Queries.Shared;

public record TransferResponse(
    Guid Id,
    string PlayerName,
    string OriginClubName,
    string DestinationClubName,
    decimal TransferValue,
    string Status,
    string Type,
    string PaymentType,
    int NumberOfInstallments,
    DateTime TransferDate
);
