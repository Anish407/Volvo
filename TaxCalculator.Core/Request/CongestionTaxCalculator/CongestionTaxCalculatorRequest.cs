namespace TaxCalculator.Core.Response.CongestionTaxCalculator
{
    public class CongestionTaxCalculatorRequest
    {
        public string City { get; set; }= string.Empty;
        public string Vehicle { get; set; } = string.Empty;

        public ICollection<DateTime> TravelDates { get; set; } = new List<DateTime>();
    }
}
