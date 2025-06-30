using MediatR;

namespace FutManagement.Application.Features.Clubs.Commands.CreateClub;

public record CreateClubCommand(
    string Name,
    Guid CountryId,
    int FoundingYear,
    decimal TransferBudget
    ) : IRequest<Guid>;