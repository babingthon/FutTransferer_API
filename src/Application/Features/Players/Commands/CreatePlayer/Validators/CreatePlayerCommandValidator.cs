using FluentValidation;

namespace FutManagement.Application.Features.Players.Commands.CreatePlayer.Validators;

public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
{
    public CreatePlayerCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Player full name is required.")
            .MaximumLength(150);

        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .LessThan(DateTime.Now.AddYears(-15)).WithMessage("Player must be at least 15 years old.");

        RuleFor(x => x.MarketValue)
            .GreaterThanOrEqualTo(0).WithMessage("Market value cannot be negative.");

        RuleFor(x => x.NationalityId)
            .NotEmpty().WithMessage("Nationality is required.");
    }
}