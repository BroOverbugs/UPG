using DTOS.HousingDTOs;
using FluentValidation;

namespace Application.Common.Validators.HousingValidators;

public class AddHousingDtoValidator : AbstractValidator<AddHousingDto>
{
    public AddHousingDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");
    }
}

public class UpdateHousingDtoValidator : AbstractValidator<UpdateHousingDto>
{
    public UpdateHousingDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");
    }
}