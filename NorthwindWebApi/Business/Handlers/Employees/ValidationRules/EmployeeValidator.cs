using Business.Handlers.Employees.Commands;
using Core.Constants;
using Core.Validation;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Employees.ValidationRules;

public class CreateEmployeeValidator : CustomValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator()
    {
        RuleFor(_ => _.FirstName).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").NotEmpty().WithMessage(ValidatorMessage.IsNull).Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.LastName).MaximumLength(20).WithMessage("Maksimum 20 karakter olmalı").NotEmpty().WithMessage(ValidatorMessage.IsNull).Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Title).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalı");
        RuleFor(_ => _.TitleOfCourtesy).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı");
        RuleFor(_ => _.Address).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı");
        RuleFor(_ => _.City).MaximumLength(10).WithMessage("Maksimum 10 karkater olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Region).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı");
        RuleFor(_ => _.PostalCode).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Country).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.HomePhone).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Extension).MaximumLength(10).WithMessage("Maksimum 10 karkater olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.ReportsTo);
    }
}

public class UpdateEmployeeValidator : CustomValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(_=>_.EmployeeId).NotEmpty();
        RuleFor(_ => _.FirstName).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").NotEmpty().WithMessage(ValidatorMessage.IsNull).Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.LastName).MaximumLength(20).WithMessage("Maksimum 20 karakter olmalı").NotEmpty().WithMessage(ValidatorMessage.IsNull).Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Title).MaximumLength(30).WithMessage("Maksimum 30 karakter olmalı");
        RuleFor(_ => _.TitleOfCourtesy).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı");
        RuleFor(_ => _.Address).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı");
        RuleFor(_ => _.City).MaximumLength(10).WithMessage("Maksimum 10 karkater olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.Region).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı");
        RuleFor(_ => _.PostalCode).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Country).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
        RuleFor(_ => _.HomePhone).MaximumLength(10).WithMessage("Maksimum 10 karakter olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.Extension).MaximumLength(10).WithMessage("Maksimum 10 karkater olmalı").Must(RegularEx.IsNumeric).WithMessage(ValidatorMessage.IsNumericMessage);
        RuleFor(_ => _.ReportsTo);
    }
}

public class DeleteEmployeeValidator : CustomValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeValidator()
    {
        RuleFor(_ => _.EmployeeId).NotEmpty();
    }
}
