namespace Coterie.Services.Validators.CommandValidators.QuoteValidators
{
    using Shared;
    using Domain.Entities;
    using FluentValidation;

    public class StateValidator : AbstractValidator<string>
    {
        public StateValidator(ICommonValidators commonValidators)
        {
            RuleFor(request => request)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .MustAsync(async (state, cancellationToken) =>
                    await commonValidators.IsExistingEntityRowAsync<State>(a => a.Name == state || a.Code == state))
             .WithMessage(state => $"State value {state} is invalid.");
        }
    }
}