namespace TaxCalculator.Core.Entities
{
    public class TaxRates
    {
        public Time TimeFrom { get; set; } = new();
        public Time TimeTo { get; set; } = new();
        public int Amount { get; set; }
    }

    public class Time
    {
        public int Hour { get; set; }
        public int Minutes { get; set; }
    }
}
