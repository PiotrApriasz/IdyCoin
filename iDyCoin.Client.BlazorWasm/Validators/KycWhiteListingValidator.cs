using FluentValidation;
using iDyCoin.Client.BlazorWasm.Models;
using iDyCoin.Metamask.Validation;

namespace iDyCoin.Client.BlazorWasm.Validators;

public class KycWhiteListingValidator : AbstractValidator<KycWhitelistingModel>
{
    public KycWhiteListingValidator()
    {
        RuleFor(x => x.AccountToWhitelist)
            .IsEthereumAddress()
            .NotEmpty()
            .NotNull();
    }
}