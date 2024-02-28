using DTOS.LaptopDTOs;
using FluentValidation;

namespace Application.Common.Validators.LaptopValidators;

public class AddLaptopDtoValidator : AbstractValidator<AddLaptopDto>
{
    public AddLaptopDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero");
    }
}

public class UpdateLaptopDtoValidator : AbstractValidator<UpdateLaptopDto>
{
    public UpdateLaptopDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero");
    }
}