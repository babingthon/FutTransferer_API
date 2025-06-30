using FutManagement.Application.Common.Exceptions;
using FutManagement.Application.Interfaces.Persistence;
using FutManagement.Core.Entities;
using FutManagement.Core.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FutManagement.Application.Features.Transfers.Commands.InitiateTransfer;

public class InitiateTransferCommandHandler : IRequestHandler<InitiateTransferCommand, Guid>
{
    private readonly IAppDbContext _context;

    public InitiateTransferCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(InitiateTransferCommand request, CancellationToken cancellationToken)
    {
        var player = await _context.Players
            .FirstOrDefaultAsync(p => p.Id == request.PlayerId, cancellationToken);
    
        var originClub = await _context.Clubs
            .FirstOrDefaultAsync(c => c.Id == request.OriginClubId, cancellationToken);
    
        var destinationClub = await _context.Clubs
            .FirstOrDefaultAsync(c => c.Id == request.DestinationClubId, cancellationToken);
        
        if (player is null)
        {
            throw new NotFoundException($"Player with ID {request.PlayerId} was not found.");
        }
    
        if (originClub is null)
        {
            throw new NotFoundException($"Origin club with ID {request.OriginClubId} not found.");
        }
    
        if (destinationClub is null)
        {
            throw new NotFoundException($"Destination club with ID {request.DestinationClubId} not found.");
        }

        if (player!.PlayerStatus == PlayerStatus.Retired)
            throw new BusinessRuleViolationException("Cannot transfer a retired player.");

        if (player.MedicalStatus == MedicalStatus.Injured)
            throw new BusinessRuleViolationException("Cannot transfer an injured player.");

        if (player.ClubId != originClub!.Id)
            throw new BusinessRuleViolationException($"Player does not belong to the origin club '{originClub.Name}'.");
            
        if (destinationClub!.TransferBudget < request.TransferValue)
            throw new BusinessRuleViolationException($"Destination club '{destinationClub.Name}' has insufficient budget. Required: {request.TransferValue}, Available: {destinationClub.TransferBudget}.");
        
        var transfer = new Transfer
        {
            Id = Guid.NewGuid(),
            PlayerId = request.PlayerId,
            OriginClubId = request.OriginClubId,
            DestinationClubId = request.DestinationClubId,
            TransferValue = request.TransferValue,
            Type = request.Type,
            Status = TransferStatus.Pending,
            TransferDate = DateTime.UtcNow, 
            CreatedAt = DateTime.UtcNow,
                
            PaymentType = request.PaymentType,
            NumberOfInstallments = request.NumberOfInstallments
        };
    
        if (request.PaymentType == PaymentType.Installments)
        {
            var installmentAmount = Math.Round(request.TransferValue / request.NumberOfInstallments, 2);
            for (int i = 1; i <= request.NumberOfInstallments; i++)
            {
                transfer.Installments.Add(new PaymentInstallment
                {
                    Id = Guid.NewGuid(),
                    Amount = installmentAmount,
                    DueDate = DateTime.UtcNow.AddMonths(i),
                    IsPaid = false,
                    CreatedAt = DateTime.UtcNow
                });
            }
        }
        else
        {
            transfer.Installments.Add(new PaymentInstallment
            {
                Id = Guid.NewGuid(),
                Amount = request.TransferValue,
                DueDate = DateTime.UtcNow.AddDays(7),
                IsPaid = false,
                CreatedAt = DateTime.UtcNow
            });
        }
        
        await _context.Transfers.AddAsync(transfer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return transfer.Id;
    }
}