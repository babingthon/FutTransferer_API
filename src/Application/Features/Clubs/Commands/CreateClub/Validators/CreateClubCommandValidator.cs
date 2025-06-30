using FluentValidation;

namespace FutManagement.Application.Features.Clubs.Commands.CreateClub.Validators;

public class CreateClubCommandValidator : AbstractValidator<CreateClubCommand>
{
    public CreateClubCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Club name is required.")
            .MaximumLength(100).WithMessage("Club name must not exceed 100 characters.");

        RuleFor(x => x.FoundingYear)
            .GreaterThan(1800).WithMessage("Founding year seems too old.")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Founding year cannot be in the future.");

        RuleFor(x => x.TransferBudget)
            .GreaterThanOrEqualTo(0).WithMessage("Transfer budget cannot be negative.");

        RuleFor(x => x.CountryId)
            .NotEmpty().WithMessage("Country is required.");  
    }  
}