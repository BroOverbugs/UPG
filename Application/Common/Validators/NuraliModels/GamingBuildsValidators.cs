using DTOS.GamingBuildsDTOs;
using FluentValidation;

namespace Application.Common.Validators.NuraliModels;

public class AddGamingBuildsDTOValidator : AbstractValidator<AddGamingBuildsDTO> 
{
    public AddGamingBuildsDTOValidator()
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

        RuleFor(dto => dto.MotherBoard)
            .NotEmpty()
            .WithMessage("MotherBoard is required!");

        RuleFor(dto => dto.CPU)
            .NotEmpty()
            .WithMessage("CPU is required!");

        RuleFor(dto => dto.Cooler)
            .NotEmpty()
            .WithMessage("Cooler is required!");

        RuleFor(dto => dto.RAM)
            .NotEmpty()
            .WithMessage("RAM is required!");

        RuleFor(dto => dto.GPU)
            .NotEmpty()
            .WithMessage("GPU is required!");

        RuleFor(dto => dto.PSU)
            .NotEmpty()
            .WithMessage("PSU is required!");

        RuleFor(dto => dto.Case)
            .NotEmpty()
            .WithMessage("Case is required!");
    }
}

public class UpdateGamingBuildsDTOValidator : AbstractValidator<UpdateGamingBuildsDTO>
{
    public UpdateGamingBuildsDTOValidator()
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

        RuleFor(dto => dto.MotherBoard)
            .NotEmpty()
            .WithMessage("MotherBoard is required!");

        RuleFor(dto => dto.CPU)
            .NotEmpty()
            .WithMessage("CPU is required!");

        RuleFor(dto => dto.Cooler)
            .NotEmpty()
            .WithMessage("Cooler is required!");

        RuleFor(dto => dto.RAM)
            .NotEmpty()
            .WithMessage("RAM is required!");

        RuleFor(dto => dto.GPU)
            .NotEmpty()
            .WithMessage("GPU is required!");

        RuleFor(dto => dto.PSU)
            .NotEmpty()
            .WithMessage("PSU is required!");

        RuleFor(dto => dto.Case)
            .NotEmpty()
            .WithMessage("Case is required!");
    }
}
