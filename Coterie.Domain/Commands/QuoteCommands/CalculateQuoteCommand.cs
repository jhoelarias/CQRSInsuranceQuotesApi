using Coterie.Domain.Responses;

namespace Coterie.Domain.Commands.QuoteCommands
{
    using Responses.Quote;
    using System.Collections.Generic;

    public class CalculateQuoteCommand : BaseCommand<ApiResponse<CalculateQuoteResponse>>
    {
        public string Business { get; set; }
        public int Revenue { get; set; }
        public IReadOnlyCollection<string> States { get; set; }
    }
}