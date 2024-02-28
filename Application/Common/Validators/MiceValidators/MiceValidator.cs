using DTOS.MiceDTOs;
using FluentValidation;

namespace Application.Common.Validators.MiceValidators;

public class AddMiceDtoValidator : AbstractValidator<AddMiceDto>
{
    public AddMiceDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .Must(i => i > 0).WithMessage("Price must be greater than zero");

        RuleFor(dto => dto.Number_of_buttons)
            .Must(i => i > 0).WithMessage("Number of buttons must be greater than zero");
    }
}


public class UpdateMiceDtoValidator : AbstractValidator<UpdateMiceDto>
{
    public UpdateMiceDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .Must(i => i > 0).WithMessage("Price must be greater than zero");

        RuleFor(dto => dto.Number_of_buttons)
            .Must(i => i > 0).WithMessage("Number of buttons must be greater than zero");
    }
}