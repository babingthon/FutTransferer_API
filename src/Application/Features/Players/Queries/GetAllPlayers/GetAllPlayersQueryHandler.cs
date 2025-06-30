using FutManagement.Application.Common.Models;
using FutManagement.Application.Features.Players.Queries.Shared;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Players.Queries.GetAllPlayers;

public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, PagedResponse<PlayerResponse>>
{
    private readonly IAppDbContext _context;

    public GetAllPlayersQueryHandler(IAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<PagedResponse<PlayerResponse>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Player> query = _context.Players
            .Include(p => p.Nationality)
            .Include(p => p.Club);

        if (!string.IsNullOrWhiteSpace(request.CountryCode))
        {
            var upperCaseCode = request.CountryCode.ToUpper();
            query = query.Where(p => p.Nationality.Code == upperCaseCode);
        }

        if (request.ClubId.HasValue)
        {
            query = query.Where(p => p.ClubId == request.ClubId.Value);
        }
  
        var totalRecords = await query.CountAsync(cancellationToken);

        var playersOnPage = await query
            .OrderBy(p => p.FullName)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize) 
            .Select(player => new PlayerResponse( 
                player.Id,
                player.FullName,
                player.Nickname,
                player.Age,
                player.Position.ToString(),
                player.MarketValue,
                player.MedicalStatus.ToString(),
                player.PlayerStatus.ToString(),
                player.Nationality.Name,
                player.Club!.Name
            ))
            .ToListAsync(cancellationToken);

        return new PagedResponse<PlayerResponse>(playersOnPage, request.PageNumber, request.PageSize, totalRecords);
    }
}