namespace FutManagement.Application.Features.Clubs.Queries.Shared;

public record ClubResponse(
    Guid Id,
    string Name,
    string CountryName,
    int FoundingYear,
    decimal TransferBugget
    );