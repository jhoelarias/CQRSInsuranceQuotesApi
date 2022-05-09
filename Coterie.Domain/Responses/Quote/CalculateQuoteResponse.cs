namespace Coterie.Domain.Responses.Quote
{
    using System.Collections.Generic;

    public class CalculateQuoteResponse
    {
        public string Business { get; init; }
        public int Revenue { get; init; }
        public IReadOnlyCollection<PremiumValues> Premiums { get; set; } = new List<PremiumValues>();
    }
}