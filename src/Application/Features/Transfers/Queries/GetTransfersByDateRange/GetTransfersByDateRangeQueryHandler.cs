using FutManagement.Application.Features.Transfers.Queries.Shared;
using FutManagement.Application.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Transfers.Queries.GetTransfersByDateRange;

public class GetTransfersByDateRangeQueryHandler : IRequestHandler<GetTransfersByDateRangeQuery, IEnumerable<TransferResponse>>
{
    private readonly IAppDbContext _context;

    public GetTransfersByDateRangeQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TransferResponse>> Handle(GetTransfersByDateRangeQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Core.Entities.Transfer> query = _context.Transfers
            .AsNoTracking()
            .Include(t => t.Player)
            .Include(t => t.OriginClub)
            .Include(t => t.DestinationClub);

        if (request.StartDate.HasValue)
        {
            query = query.Where(t => t.TransferDate.Date >= request.StartDate.Value.Date);
        }

        if (request.EndDate.HasValue)
        {
            query = query.Where(t => t.TransferDate.Date <= request.EndDate.Value.Date);
        }

        return await query
            .OrderByDescending(t => t.TransferDate)
            .Select(t => new TransferResponse(
                t.Id,
                t.Player!.FullName,
                t.OriginClub!.Name,
                t.DestinationClub!.Name,
                t.TransferValue,
                t.Status.ToString(),
                t.Type.ToString(),
                t.PaymentType.ToString(),
                t.NumberOfInstallments,
                t.TransferDate
            ))
            .ToListAsync(cancellationToken);
    } 
}