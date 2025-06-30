namespace FutManagement.Application.Features.Players.Queries.Shared;

public record PlayerResponse(
    Guid Id,
    string FullName,
    string? NickName,
    int Age,
    string Position,
    decimal MarketValue,
    string MedicalStatus,
    string PlayerStatus,
    string NationatilyName,
    string? ClubName
    );