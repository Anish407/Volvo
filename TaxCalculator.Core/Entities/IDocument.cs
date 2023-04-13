using Newtonsoft.Json;

namespace TaxCalculator.Core.Entities
{
    public abstract class IDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonIgnore]
        public abstract string PartitionKey { get; }

        [JsonIgnore]
        public string ETag { get; set; }
    }
}
