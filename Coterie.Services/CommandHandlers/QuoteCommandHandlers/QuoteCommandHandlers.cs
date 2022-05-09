﻿namespace Coterie.Services.CommandHandlers.QuoteCommandHandlers
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Domain.Responses;
    using Domain.Commands.QuoteCommands;
    using Domain.Responses.Quote;
    using MediatR;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class QuoteCommandHandlers
    {
        public class CalculateQuoteCommandHandler : IRequestHandler<CalculateQuoteCommand, ApiResponse<CalculateQuoteResponse>>
        {
            private readonly ICoterieContext _context;

            private const int HazardFactor = 4;
            private const int _premiumBaseDiv = 1000;

            public CalculateQuoteCommandHandler(ICoterieContext context)
            {
                _context = context;
            }

            public async Task<ApiResponse<CalculateQuoteResponse>> Handle(CalculateQuoteCommand request, CancellationToken cancellationToken)
            {
                var business = await _context.Businesses.FirstOrDefaultAsync(b => b.Name == request.Business, cancellationToken);

                var basePremium = Math.Ceiling(Convert.ToDouble(request.Revenue / _premiumBaseDiv));

                return new ApiResponse<CalculateQuoteResponse>
                {
                    Result = new CalculateQuoteResponse
                    {
                        Business = request.Business,
                        Revenue = request.Revenue,
                        Premiums = await _context.States
                        .Where(s => request.States.Contains(s.Name) || request.States.Contains(s.Code))
                        .OrderByDescending(s => s.Code)
                        .Select(s => new PremiumValues
                        {
                            State = s.Code.ToString(),
                            Premium = s.Factor * business.Factor * basePremium * HazardFactor
                        }).ToListAsync(cancellationToken)
                    }
                };
            }
        }
    }
}