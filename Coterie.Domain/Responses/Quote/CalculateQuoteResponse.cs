namespace Coterie.Domain.Responses.Quote
{
    using System.Collections.Generic;

    public class CalculateQuoteResponse
    {
        public string Business { get; set; }
        public int Revenue { get; set; }
        public IReadOnlyCollection<PremiumValues> Premiums { get; set; }
    }
}