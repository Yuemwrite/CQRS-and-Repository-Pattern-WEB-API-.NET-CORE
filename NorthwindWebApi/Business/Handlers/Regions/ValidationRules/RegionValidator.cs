using Business.Handlers.Regions.Commands;
using Core.Constants;
using Core.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Regions.ValidationRules;

public class CreateRegionValidator : CustomValidator<CreateRegionCommand>
{
    public CreateRegionValidator()
    {
        RuleFor(_=>_.RegionDescription).MaximumLength(50).WithMessage("Maksimum 50 karakter olmalıdır.").NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class UpdateRegionValidator : CustomValidator<UpdateRegionCommand>
{
    public UpdateRegionValidator()
    {
        RuleFor(_=>_.RegionId).NotEmpty();
        RuleFor(_ => _.RegionDescription).MaximumLength(50).WithMessage("Maksimum 50 karakter olmalıdır.").NotEmpty().WithMessage(ValidatorMessage.IsNull);
    }
}

public class DeleteRegionValidator : CustomValidator<DeleteRegionCommand>
{
    public DeleteRegionValidator()
    {
        RuleFor(_=>_.RegionId).NotEmpty();
    }
}
