using Business.Handlers.Shippers.Commands;
using Core.Constants;
using Core.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Shippers.ValidationRules;

public class CreateShipperValidator : CustomValidator<CreateShipperCommand>
{
    public CreateShipperValidator()
    {
        RuleFor(_=>_.CompanyName).MaximumLength(40).WithMessage("Maksimum 40 karakter olmalıdır.").NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(_=>_.Phone).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalıdır").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
    }
}

public class UpdateShipperValidator : CustomValidator<UpdateShipperCommand>
{
    public UpdateShipperValidator()
    {
        RuleFor(_=>_.ShipperId).NotEmpty();
        RuleFor(_ => _.CompanyName).MaximumLength(40).WithMessage("Maksimum 40 karakter olmalıdır.").NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(_ => _.Phone).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalıdır").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
    }
}

public class DeleteShipperValidator : CustomValidator<DeleteShipperCommand>
{
    public DeleteShipperValidator()
    {
        RuleFor(_ => _.ShipperId).NotEmpty();
    }
}
