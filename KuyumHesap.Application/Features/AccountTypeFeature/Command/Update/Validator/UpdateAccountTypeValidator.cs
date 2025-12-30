using FluentValidation;
using KuyumHesap.Application.Common.Extensions;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Command.Update.Validator
{
    public class UpdateAccountTypeValidator : AbstractValidator<UpdateAccountTypeCommandRequest>
    {
        public UpdateAccountTypeValidator()
        {
            RuleFor(x => x.AccountTypeName).NotNull().NotEmpty().WithMessage(string.Format(StringMessageExtension.NotNullMessage, "Hesap Tipi"));
        }
    }
}
