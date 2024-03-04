using DTOS.HeadphonesDTOs;
using FluentValidation;

namespace Application.Common.Validators.NuraliModels;

public class AddHeadphonesDTOValidator : AbstractValidator<AddHeadphonesDTO>
{
    public AddHeadphonesDTOValidator()
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

        RuleFor(dto => dto.Headphone_type)
            .NotEmpty()
            .WithMessage("Headphone type is required!");

        RuleFor(dto => dto.Operating_mode)
            .NotEmpty()
            .WithMessage("Opreating mode is required!");

        RuleFor(dto => dto.Sound_type)
            .NotEmpty()
            .WithMessage("Sound type is required!");

        RuleFor(dto => dto.Headphone_frequency_range)
            .NotEmpty()
            .WithMessage("Headphone frequency range is required!");

        RuleFor(dto => dto.Headphone_impedance)
            .NotEmpty()
            .WithMessage("headphone impedance is required!");

        RuleFor(dto => dto.Headphone_sensitivity)
            .NotEmpty()
            .WithMessage("Headphone sensitivity is required!");

        RuleFor(dto => dto.Microphone_frequency_range)
            .NotEmpty()
            .WithMessage("Microphone frequency range is required!");

        RuleFor(dto => dto.Sound_card)
            .NotEmpty()
            .WithMessage("Sound card is required!");

        RuleFor(dto => dto.Backlight)
            .NotEmpty()
            .WithMessage("Backlight is required!");

        RuleFor(dto => dto.Weight)
            .NotEmpty()
            .WithMessage("Weight is required");
    }
}

public class UpdateHeadphonesDTOValidator : AbstractValidator<UpdateHeadphonesDTO>
{
    public UpdateHeadphonesDTOValidator()
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

        RuleFor(dto => dto.Headphone_type)
            .NotEmpty()
            .WithMessage("Headphone type is required!");

        RuleFor(dto => dto.Operating_mode)
            .NotEmpty()
            .WithMessage("Opreating mode is required!");

        RuleFor(dto => dto.Sound_type)
            .NotEmpty()
            .WithMessage("Sound type is required!");

        RuleFor(dto => dto.Headphone_frequency_range)
            .NotEmpty()
            .WithMessage("Headphone frequency range is required!");

        RuleFor(dto => dto.Headphone_impedance)
            .NotEmpty()
            .WithMessage("headphone impedance is required!");

        RuleFor(dto => dto.Headphone_sensitivity)
            .NotEmpty()
            .WithMessage("Headphone sensitivity is required!");

        RuleFor(dto => dto.Microphone_frequency_range)
            .NotEmpty()
            .WithMessage("Microphone frequency range is required!");

        RuleFor(dto => dto.Sound_card)
            .NotEmpty()
            .WithMessage("Sound card is required!");

        RuleFor(dto => dto.Backlight)
            .NotEmpty()
            .WithMessage("Backlight is required!");

        RuleFor(dto => dto.Weight)
            .NotEmpty()
            .WithMessage("Weight is required");
    }
}
