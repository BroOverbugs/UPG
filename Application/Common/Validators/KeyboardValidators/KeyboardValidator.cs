using DTOS.KeyboardDTOs;
using FluentValidation;

namespace Application.Common.Validators.KeyboardValidators;

public class UpdateKeyboardDtoValidator : AbstractValidator<UpdateKeyboardDto>
{
    public UpdateKeyboardDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .Must(i => i > 0).WithMessage("Price must be greater than zero");

        RuleFor(dto => dto.Number_of_keys)
            .Must(i => i > 0).WithMessage("Number of keys must be greater than zero");
    }
}

public class AddKeyboardDtoValidator : AbstractValidator<AddKeyboardDto>
{
    public AddKeyboardDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .Must(i => i > 0).WithMessage("Price must be greater than zero");

        RuleFor(dto => dto.Number_of_keys)
            .Must(i => i > 0).WithMessage("Number of keys must be greater than zero");
    }
}