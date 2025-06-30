using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Application.Interfaces.Services;
using FutManagement.Core.Enums;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Transfers.Commands.FinalizeTransfer;

public class FinalizeTransferCommandHandler : IRequestHandler<FinalizeTransferCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public FinalizeTransferCommandHandler(IAppDbContext context, IBackgroundJobClient backgroundJobClient)
    {
        _context = context;
        _backgroundJobClient = backgroundJobClient;
    }
    
        public async Task<bool> Handle(FinalizeTransferCommand request, CancellationToken cancellationToken)
    {
        var transfer = await _context.Transfers
            .Include(t => t.Player)
            .Include(t => t.OriginClub)
            .Include(t => t.DestinationClub)
            .FirstOrDefaultAsync(t => t.Id == request.TransferId, cancellationToken);
    
        if (transfer is null)
        {
            throw new NotFoundException($"Transfer with ID {request.TransferId} not found.");
        }

        if (transfer.Status != TransferStatus.Pending && transfer.Status != TransferStatus.Approved)
        {
            throw new BusinessRuleViolationException($"Cannot finalize a transfer with status '{transfer.Status}'.");
        }
    
        if (transfer.Player!.PlayerStatus == PlayerStatus.Retired)
            throw new BusinessRuleViolationException("Cannot finalize transfer for a retired player.");

        if (transfer.Player.MedicalStatus == MedicalStatus.Injured)
            throw new BusinessRuleViolationException("Cannot finalize transfer for an injured player.");

        if (transfer.DestinationClub!.TransferBudget < transfer.TransferValue)
            throw new BusinessRuleViolationException("Destination club has insufficient budget.");

        transfer.DestinationClub.TransferBudget -= transfer.TransferValue;
        transfer.OriginClub!.TransferBudget += transfer.TransferValue;

        transfer.Player.ClubId = transfer.DestinationClubId;

        transfer.Status = TransferStatus.Completed;
        transfer.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        _backgroundJobClient.Enqueue<IEmailService>(service => service.SendTransferNotificationEmail(transfer.Id));
        return true;
    }
}
