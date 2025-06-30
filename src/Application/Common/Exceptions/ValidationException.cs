using FluentValidation.Results;

namespace FutManagement.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : base("One or more validation errors occurred.")
    {
        Errors = failures
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                failureGroup => failureGroup.Key,
                failureGroup => failureGroup.Select(e => e.ErrorMessage).ToArray()
            );
    }
}