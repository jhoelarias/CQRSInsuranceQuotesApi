namespace Coterie.Services.Validators.CommandValidators.CommissionPlanValidators
{
    using Domain.Commands.QuoteCommands;
    using Domain.Entities;
    using Domain.Enums;
    using Domain.Extensions;
    using FluentValidation;
    using System;
    using System.Collections.Generic;

    public class CalculateQuoteCommandValidator : AbstractValidator<CalculateQuoteCommand>
    {
        private static readonly List<State> _states = new();

        public CalculateQuoteCommandValidator()
        {
            _states.Add(new State { Name = StatesEnum.OH.GetDescription(), Code = StatesEnum.OH, Factor = 1 });
            _states.Add(new State { Name = StatesEnum.FL.GetDescription(), Code = StatesEnum.FL, Factor = 1.2 });
            _states.Add(new State { Name = StatesEnum.TX.GetDescription(), Code = StatesEnum.TX, Factor = 0.943 });

            RuleFor(request => request.Business)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .Must(request => Enum.TryParse<BusinessEnum>(request, true, out var business))
                .WithMessage(request => $"Business value {request} is invalid.");

            RuleFor(request => request.Revenue).NotEmpty();
            RuleFor(request => request.States).NotNull();

            RuleForEach(request => request.States).SetValidator(new StateValidator());
        }
    }
}