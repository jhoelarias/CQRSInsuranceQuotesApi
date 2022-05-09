namespace Coterie.Domain.Commands.QuoteCommands
{
    using Responses;
    using Responses.Quote;
    using System.Collections.Generic;

    public class CalculateQuoteCommand : BaseCommand<GenericResponse<CalculateQuoteResponse>>
    {
        public string Business { get; set; }
        public int Revenue { get; set; }
        public IReadOnlyCollection<string> States { get; set; }
    }
}