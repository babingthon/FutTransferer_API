using FluentValidation;
using FutManagement.Core.Enums;

namespace FutManagement.Application.Features.Transfers.Commands.InitiateTransfer.Validators;

public class InitiateTransferCommandValidator : AbstractValidator<InitiateTransferCommand>
{
    public InitiateTransferCommandValidator()
    {
        RuleFor(x => x.PlayerId).NotEmpty();
        RuleFor(x => x.OriginClubId).NotEmpty();
        RuleFor(x => x.DestinationClubId).NotEmpty();

        RuleFor(x => x.TransferValue)
            .GreaterThanOrEqualTo(0).WithMessage("Transfer value cannot be negative.");

        RuleFor(x => x)
            .Must(command => command.OriginClubId != command.DestinationClubId)
            .WithMessage("Origin and destination clubs cannot be the same.");
        
        RuleFor(x => x.NumberOfInstallments)
            .Equal(1)
            .When(x => x.PaymentType == PaymentType.LumpSum)
            .WithMessage("For a Lump Sum payment, the number of installments must be exactly 1.");

        RuleFor(x => x.NumberOfInstallments)
            .GreaterThanOrEqualTo(2)
            .When(x => x.PaymentType == PaymentType.Installments)
            .WithMessage("For Installment plans, the number of installments must be 2 or greater.");
    }
}