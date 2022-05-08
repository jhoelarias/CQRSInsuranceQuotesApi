using Coterie.Domain.Enums;
using Coterie.Domain.Extensions;
using Coterie.Domain.Responses;
using System.Linq;

namespace Coterie.Services.CommandHandlers.QuoteCommandHandlers
{
    using Domain.Commands.QuoteCommands;
    using Domain.Entities;
    using Domain.Responses.Quote;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class QuoteCommandHandlers
    {
        public class CalculateQuoteCommandHandler : IRequestHandler<CalculateQuoteCommand, ApiResponse<CalculateQuoteResponse>>
        {
            private static List<State> _states = new()
            {
                new State { Name = StatesEnum.OH.GetDescription(), Code = StatesEnum.OH, Factor = 1 },
                new State { Name = StatesEnum.FL.GetDescription(), Code = StatesEnum.FL, Factor = 1.2 },
                new State { Name = StatesEnum.TX.GetDescription(), Code = StatesEnum.TX, Factor = 0.943 }
            };

            private static readonly List<Business> _businesses = new()
            {
                new Business { Name = BusinessEnum.Architect, Factor = 1 },
                new Business { Name = BusinessEnum.Plumber, Factor = 0.5 },
                new Business { Name = BusinessEnum.Programmer, Factor = 1.25 }
            };

            private const int HazardFactor = 4;
            private const int _premiumBaseDiv = 1000;

            public Task<ApiResponse<CalculateQuoteResponse>> Handle(CalculateQuoteCommand request, CancellationToken cancellationToken)
            {
                var business = _businesses.FirstOrDefault(b => b.Name.ToString() == request.Business);

                var basePremium = Math.Ceiling(Convert.ToDouble(request.Revenue / _premiumBaseDiv));

                return Task.FromResult(new ApiResponse<CalculateQuoteResponse>
                {
                    Result = new CalculateQuoteResponse
                    {
                        Business = request.Business,
                        Revenue = request.Revenue,
                        Premiums = _states
                        .Where(s => request.States.Contains(s.Name) || request.States.Contains(s.Code.ToString()))
                        .OrderByDescending(s => s.Code)
                        .Select(s => new PremiumValues
                        {
                            State = s.Code.ToString(),
                            Premium = s.Factor * business.Factor * basePremium * HazardFactor
                        }).ToList()
                    }
                });
            }
        }
    }
}