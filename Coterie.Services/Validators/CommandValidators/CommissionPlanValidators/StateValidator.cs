namespace Coterie.Services.Validators.CommandValidators.CommissionPlanValidators
{
    using Domain.Entities;
    using Domain.Enums;
    using Domain.Extensions;
    using FluentValidation;
    using System.Collections.Generic;
    using System.Linq;

    public class StateValidator : AbstractValidator<string>
    {
        private static readonly List<State> _states = new();

        public StateValidator()
        {
            _states.Add(new State { Name = StatesEnum.OH.GetDescription(), Code = StatesEnum.OH, Factor = 1 });
            _states.Add(new State { Name = StatesEnum.FL.GetDescription(), Code = StatesEnum.FL, Factor = 1.2 });
            _states.Add(new State { Name = StatesEnum.TX.GetDescription(), Code = StatesEnum.TX, Factor = 0.943 });

            RuleFor(request => request)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .Must(state => _states.Any(a => a.Name == state) || _states.Any(a => a.Code.ToString() == state))
             .WithMessage(state => $"State value {state} is invalid.");
        }
    }
}