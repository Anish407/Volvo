using Newtonsoft.Json;

namespace TaxCalculator.Core.Entities
{
    public class City : IDocument
    {
        public ICollection<TaxRates> TaxRates { get; set; } = new List<TaxRates>();

        public ICollection<Holidays> TollFreeDates { get; set; } = new List<Holidays>();

        public ICollection<string> TollFreeVehicles { get; set; } = new List<string>();

        public override string PartitionKey => Id;
    }


    public class Holidays
    {
        public int Month { get; set; }

        public int[] Days { get; set; } = Array.Empty<int>();
    }

}
