using DTOS.Tables_for_gamers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validators.ElyorbekModels.TablesForGamersValidators;

public class AddTablesForGamersDTOValidator : AbstractValidator<AddTablesForGamersDTO>
{
    public AddTablesForGamersDTOValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.Price).NotEmpty().WithMessage("Price is required");

        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");

        RuleFor(dto => dto.Weight).NotEmpty().WithMessage("Weight is required");

        RuleFor(dto => dto.Dimensions).NotEmpty().WithMessage("Dimensions is required");

        RuleFor(dto => dto.I_or_O_panel).NotEmpty().WithMessage("I or O panel is required");

        RuleFor(dto => dto.Backlight).NotEmpty().WithMessage("Backlight is required");

        RuleFor(dto => dto.Max_load_up).NotEmpty().WithMessage("Max load up is required");

        RuleFor(dto => dto.Table_adjustment).NotEmpty().WithMessage("Table adjustment is required");
    }
}

public class UpdateTablesForGamersDTOValidator : AbstractValidator<UpdateTablesForGamersDTO>
{
    public UpdateTablesForGamersDTOValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(dto => dto.Price).Must(i => i > 0).WithMessage("Price must be a non-negative value");

        RuleFor(dto => dto.Price).NotEmpty().WithMessage("Price is required");

        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.BrandName).NotEmpty().WithMessage("Brand is required");

        RuleFor(dto => dto.Weight).NotEmpty().WithMessage("Weight is required");

        RuleFor(dto => dto.Dimensions).NotEmpty().WithMessage("Dimensions is required");

        RuleFor(dto => dto.I_or_O_panel).NotEmpty().WithMessage("I or O panel is required");

        RuleFor(dto => dto.Max_load_up).NotEmpty().WithMessage("Max load up is required");

        RuleFor(dto => dto.Table_adjustment).NotEmpty().WithMessage("Table adjustment is required");
    }
}