using DTOS.CoolerDTOs;
using FluentValidation;

namespace Application.Common.Validators.NuraliModels;

public class AddCoolerDTOValidator : AbstractValidator<AddCoolerDTO>
{
    public AddCoolerDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .WithMessage("Name is required!");

        RuleFor(dto => dto.Price)
            .NotEmpty()
            .WithMessage("Price is required!")

            .Must(n => n > 0)
            .WithMessage("Price must be a non - negative value!");

        RuleFor(dto => dto.BrandName)
            .NotEmpty()
            .WithMessage("Brand name is required!");

        RuleFor(dto => dto.Type)
            .NotEmpty()
            .WithMessage("Type is required!");

        RuleFor(dto => dto.Socket)
            .NotEmpty()
            .WithMessage("Socket is required!");

        RuleFor(dto => dto.Power_dissipation)
            .NotEmpty()
            .WithMessage("Power dissipation is required!");

        RuleFor(dto => dto.Dimensions)
            .NotEmpty()
            .WithMessage("Dimensions is required!");

        RuleFor(dto => dto.Dimensions_of_complete_fans)
            .NotEmpty()
            .WithMessage("Dimensions of complete fans is required!");

        RuleFor(dto => dto.Bearing_type)
            .NotEmpty()
            .WithMessage("Bearing type is required!");

        RuleFor(dto => dto.Rotational_speed)
            .NotEmpty()
            .WithMessage("Rotational speed is required!");
    }
}

public class UpdateCoolerDTOValidator : AbstractValidator<UpdateCoolerDTO>
{
    public UpdateCoolerDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .WithMessage("Name is required!");

        RuleFor(dto => dto.Price)
            .NotEmpty()
            .WithMessage("Price is required!")

            .Must(n => n > 0)
            .WithMessage("Price must be a non - negative value!");

        RuleFor(dto => dto.BrandName)
            .NotEmpty()
            .WithMessage("Brand name is required!");

        RuleFor(dto => dto.Type)
            .NotEmpty()
            .WithMessage("Type is required!");

        RuleFor(dto => dto.Socket)
            .NotEmpty()
            .WithMessage("Socket is required!");

        RuleFor(dto => dto.Power_dissipation)
            .NotEmpty()
            .WithMessage("Power dissipation is required!");

        RuleFor(dto => dto.Dimensions)
            .NotEmpty()
            .WithMessage("Dimensions is required!");

        RuleFor(dto => dto.Dimensions_of_complete_fans)
            .NotEmpty()
            .WithMessage("Dimensions of complete fans is required!");

        RuleFor(dto => dto.Bearing_type)
            .NotEmpty()
            .WithMessage("Bearing type is required!");

        RuleFor(dto => dto.Rotational_speed)
            .NotEmpty()
            .WithMessage("Rotational speed is required!");
    }
}
