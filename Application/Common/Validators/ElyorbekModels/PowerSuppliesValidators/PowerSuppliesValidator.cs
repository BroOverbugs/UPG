using DTOS.Power_supplies;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validators.ElyorbekModels.PowerSuppliesValidators;

public class AddPowerSuppliesDTOValidator : AbstractValidator<AddPowerSuppliesDTO>
{
    public AddPowerSuppliesDTOValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.Price).NotEmpty().WithMessage("Price is required");

        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");

        RuleFor(dto => dto.Dimensions).NotEmpty().WithMessage("Dimensions is required!!!");

        RuleFor(dto => dto.Power).NotEmpty().WithMessage("Power is required!!!");

        RuleFor(dto => dto.Security_technologies).NotEmpty().WithMessage("Security technologies is required");

        RuleFor(dto => dto.Form_factor).NotEmpty().WithMessage("Form Factor is required");

        RuleFor(dto => dto.Certificate).NotEmpty().WithMessage("Certificate is required!!!");
    }
}

public class UpdatePowerSuppliesDTOValidator : AbstractValidator<UpdatePowerSuppliesDTO>
{
    public UpdatePowerSuppliesDTOValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.Price).NotEmpty().WithMessage("Price is required");

        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");

        RuleFor(dto => dto.Dimensions).NotEmpty().WithMessage("Dimensions is required!!!");

        RuleFor(dto => dto.Certificate).NotEmpty().WithMessage("Certificate is required!!!");

        RuleFor(dto => dto.Power).NotEmpty().WithMessage("Power is required");

        RuleFor(dto => dto.Security_technologies).NotEmpty().WithMessage("Security technologies is required");

        RuleFor(dto => dto.Form_factor).NotEmpty().WithMessage("Form Factor is required");
    }
}