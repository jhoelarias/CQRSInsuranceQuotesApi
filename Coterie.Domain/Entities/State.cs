namespace Coterie.Domain.Entities
{
    using Enums;

    public class State
    {
        public StatesEnum Code { get; set; }
        public string Name { get; set; }
        public double Factor { get; set; }
    }
}