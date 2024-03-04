using DTOS.ArmchairsDTOs;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Application.Common.Validators.NuraliModels;

public class AddArmchairsDTOValidator : AbstractValidator<AddArmchairsDTO>
{
    public AddArmchairsDTOValidator()
    {
        RuleFor(dto =>  dto.Name)
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

        RuleFor(dto => dto.Upholstery_material)
            .NotEmpty()
            .WithMessage("Upholstery material is required!");

        RuleFor(dto => dto.Color_material)
            .NotEmpty()
            .WithMessage("Color material is required!");

        RuleFor(dto => dto.Armrests)
            .NotEmpty()
            .WithMessage("Armrests is required!");

        RuleFor(dto => dto.Reclining)
            .NotEmpty()
            .WithMessage("Reclining is required!");
    }
}

public class UpdateArmchairsDTOValidator : AbstractValidator<UpdateArmchairsDTO>
{
    public UpdateArmchairsDTOValidator()
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

        RuleFor(dto => dto.Upholstery_material)
            .NotEmpty()
            .WithMessage("Upholstery material is required!");

        RuleFor(dto => dto.Color_material)
            .NotEmpty()
            .WithMessage("Color material is required!");

        RuleFor(dto => dto.Armrests)
            .NotEmpty()
            .WithMessage("Armrests is required!");

        RuleFor(dto => dto.Reclining)
            .NotEmpty()
            .WithMessage("Reclining is required!");
    }
}
