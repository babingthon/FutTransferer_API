using FutManagement.Application.Features.Clubs.Queries.Shared;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FutManagement.Application.Features.Clubs.Queries.Queries.GetAllClubs;

public class GetAllClubsQueryHandler : IRequestHandler<GetAllClubsQuery, IEnumerable<ClubResponse>>
{
    private readonly IAppDbContext _context;

    public GetAllClubsQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClubResponse>> Handle(GetAllClubsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Club> query = _context.Clubs;

        if (!string.IsNullOrWhiteSpace(request.CountryCode))
        {
            var upperCaseCode = request.CountryCode.ToUpper();
            query = query.Where(club => club.Country.Code == upperCaseCode);
        }

        return await query
            .OrderBy(club => club.Name)
            .Select(club => new ClubResponse(
                club.Id,
                club.Name,
                club.Country.Name + " - " + club.Country.Code,
                club.FoundingYear,
                club.TransferBudget
            ))
            .ToListAsync(cancellationToken);
    }
}

