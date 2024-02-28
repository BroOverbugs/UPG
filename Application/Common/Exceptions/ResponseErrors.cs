using FluentValidation.Results;

namespace Application.Common.Exceptions;

public class ResponseErrors : Exception
{
    public List<ValidationFailure> Errors { get; set; } = new();
}
