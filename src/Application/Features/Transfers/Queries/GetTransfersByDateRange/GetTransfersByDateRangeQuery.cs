using FutManagement.Application.Features.Transfers.Queries.Shared;
using MediatR;

namespace FutManagement.Application.Features.Transfers.Queries.GetTransfersByDateRange;

public record GetTransfersByDateRangeQuery(
    DateTime? StartDate,
    DateTime? EndDate
    ) : IRequest<IEnumerable<TransferResponse>>;