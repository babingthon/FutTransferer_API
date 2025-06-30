namespace FutManagement.Application.Features.Countries.Queries.Shared;

public record CountryResponse(
    Guid Id,
    string Name,
    string Code
    );