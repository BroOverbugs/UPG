using DTOS.HousingDTOs;
using DTOS.Mouse_pads;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validators.ElyorbekModels.MousePadsValidators;

public class AddMousePadsDtoValidator : AbstractValidator<AddMousePadsDTO>
{
    public AddMousePadsDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.Price).NotEmpty().WithMessage("Price is required");

        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");

        RuleFor(dto => dto.Dimensions).NotEmpty().WithMessage("Dimensions is required!!!");

        RuleFor(dto => dto.Material).NotEmpty().WithMessage("Material is required!!!");
    }
}

public class UpdateMousePadsDtoValidator : AbstractValidator<UpdateMousePadsDTO>
{
    public UpdateMousePadsDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.Price).NotEmpty().WithMessage("Price is required");

        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");

        RuleFor(dto => dto.Dimensions).NotEmpty().WithMessage("Dimensions is required!!!");

        RuleFor(dto => dto.Material).NotEmpty().WithMessage("Material is required!!!");
    }
}