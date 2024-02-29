using DTOS.Power_supplies;
using DTOS.RAM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validators.ElyorbekModels.RAMValidators;

public class AddRAMDTOValidator : AbstractValidator<AddRAMDTO>
{
    public AddRAMDTOValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.Price).NotEmpty().WithMessage("Price is required");

        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");

        RuleFor(dto => dto.Capacity).NotEmpty().WithMessage("Capacity is required");

        RuleFor(dto => dto.Technologies).NotEmpty().WithMessage("Technologies is required");

        RuleFor(dto => dto.Memory_frequency).NotEmpty().WithMessage("Memory Frequency is required");

        RuleFor(dto => dto.Backlight).NotEmpty().WithMessage("Backlight is required");

        RuleFor(dto => dto.Timings).NotEmpty().WithMessage("Timings is required");
    }
}

public class UpdateRAMDTOValidator : AbstractValidator<UpdateRAMDTO>
{
    public UpdateRAMDTOValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.Price).NotEmpty().WithMessage("Price is required");

        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");

        RuleFor(dto => dto.Capacity).NotEmpty().WithMessage("Capacity is required");

        RuleFor(dto => dto.Technologies).NotEmpty().WithMessage("Technologies is required");

        RuleFor(dto => dto.Memory_frequency).NotEmpty().WithMessage("Memory Frequency is required");

        RuleFor(dto => dto.Backlight).NotEmpty().WithMessage("Backlight is required");

        RuleFor(dto => dto.Timings).NotEmpty().WithMessage("Timings is required");
    }
}