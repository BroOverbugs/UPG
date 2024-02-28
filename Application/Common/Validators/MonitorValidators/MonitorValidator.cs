using DTOS.MonitorDTOs;
using FluentValidation;

namespace Application.Common.Validators.MonitorValidators;

public class AddMonitorDtoValidator : AbstractValidator<AddMonitorDto>
{
    public AddMonitorDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero");
    }
}

public class UpdateMonitorDtoValidator : AbstractValidator<UpdateMonitorDto>
{
    public UpdateMonitorDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name cannot be empty");

        RuleFor(dto => dto.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero");
    }
}
