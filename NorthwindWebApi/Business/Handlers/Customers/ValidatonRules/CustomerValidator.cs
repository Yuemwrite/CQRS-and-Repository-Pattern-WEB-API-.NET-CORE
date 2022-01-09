using Business.Handlers.Customers.Commands;
using Business.Handlers.Products.Commands;
using Core.Constants;
using Core.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Customers.ValidatonRules;

public class CreateCustomerValidator : CustomValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(_=>_.CompanyName).MaximumLength(40).WithMessage("Maksimum 40 karakter olmalı").NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(_=>_.ContactName).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.ContactTitle).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalı");
        RuleFor(_ => _.Address).MaximumLength(60).WithMessage("Maksimum 60 karakter olmalı");
        RuleFor(_ => _.City).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Region).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalı");
        RuleFor(_ => _.PostalCode).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Country).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Phone).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Fax).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
    }
}


public class UpdateCustomerValidator: CustomValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(_=>_.CustomerId).NotEmpty();
        RuleFor(_ => _.ContactName).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.ContactTitle).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalı");
        RuleFor(_ => _.Address).MaximumLength(60).WithMessage("Maksimum 60 karakter olmalı");
        RuleFor(_ => _.City).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Region).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalı");
        RuleFor(_ => _.PostalCode).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Country).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Phone).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Fax).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
    }
}
