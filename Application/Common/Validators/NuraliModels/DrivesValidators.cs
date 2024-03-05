using DTOS.DrivesDTOs;
using FluentValidation;

namespace Application.Common.Validators.NuraliModels;

public class AddDrivesDTOValidator : AbstractValidator<AddDrivesDTO>
{
    public AddDrivesDTOValidator()
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

        RuleFor(dto => dto.Interface)
            .NotEmpty()
            .WithMessage("Interface is required!");

        RuleFor(dto => dto.Reading_speed)
            .NotEmpty()
            .WithMessage("Reading speed is required!");

        RuleFor(dto => dto.Write_type)
            .NotEmpty()
            .WithMessage("Write type is required!");

        RuleFor(dto => dto.Drive_type)
            .NotEmpty()
            .WithMessage("Drive type is required!");

        RuleFor(dto => dto.Volume)
            .NotEmpty()
            .WithMessage("Volume is required!");
    }
}

public class UpdateDrivesDTOValidator : AbstractValidator<UpdateDrivesDTO>
{
    public UpdateDrivesDTOValidator()
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

        RuleFor(dto => dto.Interface)
            .NotEmpty()
            .WithMessage("Interface is required!");

        RuleFor(dto => dto.Reading_speed)
            .NotEmpty()
            .WithMessage("Reading speed is required!");

        RuleFor(dto => dto.Write_type)
            .NotEmpty()
            .WithMessage("Write type is required!");

        RuleFor(dto => dto.Drive_type)
            .NotEmpty()
            .WithMessage("Drive type is required!");

        RuleFor(dto => dto.Volume)
            .NotEmpty()
            .WithMessage("Volume is required!");
    }
}
