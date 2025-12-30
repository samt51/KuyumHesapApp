using FluentValidation;
using KuyumHesap.Application.Common.Extensions;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Command.Create.Validators
{
    public class AccountTypeValidator : AbstractValidator<CreateAccountTypeCommandRequest>
    {
        public AccountTypeValidator()
        {
            RuleFor(x => x.AccountTypeName).NotNull().NotEmpty().WithMessage(string.Format(StringMessageExtension.NotNullMessage, "Hesap Tipi"));
        }
    }
}
