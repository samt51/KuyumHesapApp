using FluentValidation;
using KuyumHesap.Application.Common.Extensions;
using KuyumHesap.Application.Features.AccountFeature.Command.Create;

namespace KuyumHesap.Application.Features.AccountFeature.Validators
{
    public class AccountValidator : AbstractValidator<CreateAccountCommandRequest>
    {
        public AccountValidator()
        {
            RuleFor(x => x.AccountName).NotNull().NotEmpty().WithMessage(string.Format(StringMessageExtension.NotNullMessage,"Hesap"));
        }
    }
}
