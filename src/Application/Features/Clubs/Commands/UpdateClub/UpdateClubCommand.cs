using MediatR;

namespace FutManagement.Application.Features.Clubs.Commands.UpdateClub;

public record UpdateClubCommand(
    Guid Id,
    string Name,
    Guid CountryId,
    int FoundingYear,
    decimal TransferBudget
    ) : IRequest<bool>;