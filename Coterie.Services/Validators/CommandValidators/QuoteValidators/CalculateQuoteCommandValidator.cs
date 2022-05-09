using Coterie.Services.Validators.Shared;

namespace Coterie.Services.Validators.CommandValidators.QuoteValidators
{
    using Domain.Commands.QuoteCommands;
    using Domain.Entities;
    using FluentValidation;

    public class CalculateQuoteCommandValidator : AbstractValidator<CalculateQuoteCommand>
    {
        public CalculateQuoteCommandValidator(ICommonValidators commonValidators)
        {
            RuleFor(request => request.Business)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .MustAsync(async (businessName, cancellationToken) =>
                    await commonValidators.IsExistingEntityRowAsync<Business>(u => u.Name == businessName))
                .WithMessage(request => $"Business value {request} is invalid.");

            RuleFor(request => request.Revenue).NotEmpty();
            RuleFor(request => request.States).NotNull();

            RuleForEach(request => request.States).SetValidator(new StateValidator(commonValidators));
        }
    }
}