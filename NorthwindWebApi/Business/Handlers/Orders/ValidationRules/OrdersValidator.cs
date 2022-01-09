using Business.Handlers.Orders.Commands;
using Core.Constants;
using Core.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Orders.ValidationRules;

public class CreateOrdersValidator : CustomValidator<CreateOrderCommand>
{
    public CreateOrdersValidator()
    {
        RuleFor(_=>_.ShipName).MaximumLength(40).WithMessage("Maksimum 40 karakter olmalıdır.");
        RuleFor(_=>_.ShipAddress).MaximumLength(60).WithMessage("Maksimum 60 karakter olmalıdır");
        RuleFor(_=>_.ShipCity).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalıdır").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_=>_.ShipRegion).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalıdır");
        RuleFor(_=>_.ShipPostalCode).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalıdır").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_=>_.ShipCountry).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalıdır");
        RuleFor(_=>_.ShipperId);
        RuleFor(_=>_.EmployeeId);
        RuleFor(_=>_.CustomerId);
    }
}
