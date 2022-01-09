using Business.Handlers.Suppliers.Commands;
using Core.Constants;
using Core.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Handlers.Suppliers.ValidationRules;


public class CreateSupplierValidator : CustomValidator<CreateSupplierCommand>
{
    public CreateSupplierValidator()
    {
        RuleFor(_=>_.CompanyName).MaximumLength(40).WithMessage("Maksimum 40 karakter olmalıdır.").NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(_=>_.ContactName).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalıdır.");
        RuleFor(_=>_.ContactTitle).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalıdır.");
        RuleFor(_=>_.Address).MaximumLength(60).WithMessage("Maksimum 60 karakter olmalıdır.");
        RuleFor(_ => _.City).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalıdır.").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_=>_.Region).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalıdır.");
        RuleFor(_=>_.PostalCode).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalıdır").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_=>_.Country).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalıdır").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_=>_.Phone).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalıdır.").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_=>_.Fax).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalıdır").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsStringMessage);
    } 
}

public class UpdateSupplierValidator : CustomValidator<UpdateSupplierCommand>
{
    public UpdateSupplierValidator()
    {
        RuleFor(_=>_.SupplierId).NotEmpty();
        RuleFor(_ => _.ContactName).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalıdır.");
        RuleFor(_ => _.ContactTitle).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalıdır.");
        RuleFor(_ => _.Address).MaximumLength(60).WithMessage("Maksimum 60 karakter olmalıdır.");
        RuleFor(_ => _.City).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalıdır.").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Region).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalıdır.");
        RuleFor(_ => _.PostalCode).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalıdır").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Country).MaximumLength(15).WithMessage("Maksimum 15 karakter olmalıdır").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Phone).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalıdır.").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Fax).MaximumLength(24).WithMessage("Maksimum 24 karakter olmalıdır").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsStringMessage);
    }
}

public class DeleteSupplierValidator : CustomValidator<DeleteSupplierCommand>
{
    public DeleteSupplierValidator()
    {
        RuleFor(_ => _.SupplierId).NotEmpty();
    }
}
