using Business.Handlers.Categories.Commands;
using Core.Constants;
using Core.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Categories.ValidationRules;

public class CreateCategoriesValidator : CustomValidator<CreateCategoryCommand>
{
    public CreateCategoriesValidator()
    {
        RuleFor(_ => _.CategoryName).MaximumLength(64).WithMessage("Maksimum 64 karakter olmalıdır").NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(_ => _.Description).MaximumLength(32).WithMessage("Maksimum 32 karakter olmalıdır").Must(RegularEx.IsString).WithMessage(ValidatorMessage.IsStringMessage);
    }
}

public class UpdateCategoriesValidator : CustomValidator<UpdateCategoryCommand>
{
    public UpdateCategoriesValidator()
    {
        RuleFor(_=>_.CategoryId).NotEmpty();
        RuleFor(_ => _.CategoryName).MaximumLength(64).WithMessage("Maksimum 64 karakter olmalıdır").NotEmpty().WithMessage(ValidatorMessage.IsNull);
        RuleFor(_ => _.Description).MaximumLength(32).WithMessage("Maksimum 32 karakter olmalıdır.");
    }
}

public class DeleteCategoriesValidator : CustomValidator<DeleteCategoryCommand>
{
    public DeleteCategoriesValidator()
    {
        RuleFor(_ => _.CategoryId).NotEmpty();
    }
}
