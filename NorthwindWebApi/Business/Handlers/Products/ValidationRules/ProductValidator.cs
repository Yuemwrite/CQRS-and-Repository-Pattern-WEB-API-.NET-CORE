using Business.Handlers.Products.Commands;
using Core.Constants;
using Core.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Products.ValidationRules;

public class CreateProductValidator : CustomValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(_=>_.ProductName).MaximumLength(40).WithMessage("Maksimum 40 karakter olmalıdır").NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(_=>_.QuantityPerUnit).MaximumLength(20).WithMessage("Maksimum 20 karakter olmalıdır.");
        RuleFor(_ => _.UnitPrice);
        RuleFor(_=>_.UnitsInStock);
        RuleFor(_=>_.UnitsOnOrder);
        RuleFor(_=>_.ReorderLevel);
        RuleFor(_=>_.Discontinued);
        RuleFor(_=>_.CategoryId);
        RuleFor(_=>_.SupplierId);
    }
}
public class UpdateProductValidator : CustomValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(_=>_.ProductId).NotEmpty();
        RuleFor(_ => _.ProductName).MaximumLength(40).WithMessage("Maksimum 40 karakter olmalıdır").NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(_ => _.QuantityPerUnit).MaximumLength(20).WithMessage("Maksimum 20 karakter olmalıdır.");
        RuleFor(_ => _.UnitPrice);
        RuleFor(_ => _.UnitsInStock);
        RuleFor(_ => _.UnitsOnOrder);
        RuleFor(_ => _.ReorderLevel);
        RuleFor(_ => _.Discontinued);
        RuleFor(_ => _.CategoryId);
        RuleFor(_ => _.SupplierId);
    }
}

public class DeleteProductValidator : CustomValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(_ => _.ProductId).NotEmpty();
    }
}
