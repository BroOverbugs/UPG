using DTOS.AccessoriesDtos;
using DTOS.MonitorDTOs;
using FluentValidation;

namespace Application.Common.Validators.AccessoriesValidators;
public class AccessoriesValidator : AbstractValidator<AddAccessoriesDto>
{
    public AccessoriesValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .Must(i => i > 0).WithMessage("Price must be greater than zero");

        RuleFor(dto => dto.BrandName)
            .NotEmpty().WithMessage("BrandName cannot be empty");
    }
}
public class UpdateAccessoriesDtoValidator : AbstractValidator<UpdateAccessoriesDto>
{
    public UpdateAccessoriesDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .Must(i => i > 0).WithMessage("Price must be greater than zero");

        RuleFor(dto => dto.BrandName)
            .NotEmpty().WithMessage("BrandName cannot be empty");
    }
}
