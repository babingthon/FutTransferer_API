using System.Globalization;
using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Features.Clubs.Queries.Shared;
using FutManagement.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Clubs.Queries.Queries.GetClubById;

public class GetClubByIdQueryHandler : IRequestHandler<GetClubByIdQuery, ClubResponse?>
{
    private readonly IAppDbContext _context;

    public GetClubByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<ClubResponse?> Handle(GetClubByIdQuery request, CancellationToken cancellationToken)
    {
        var club = await _context.Clubs
            .AsNoTracking()
            .Include(c => c.Country)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (club is null)
        {
            throw new NotFoundException($"Club with ID {request.Id} was not found.");
        }

        return new ClubResponse(
            club.Id,
            club.Name,
            club.Country.Name,
            club.FoundingYear,
            club.TransferBudget
        );
    }
}