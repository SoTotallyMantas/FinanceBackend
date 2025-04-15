using FinanceBackend.NewFolder;
using System.Text.Json.Serialization;

namespace FinanceBackend.Entities.Finnhub
{
    public class CompanyNews
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }
        // Convert To DateTime YYYY-MM-dd
        [JsonPropertyName("datetime")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime datetime { get; set; }
        [JsonPropertyName("headline")]
        public string Headline { get; set; }
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("image")]
        public string image { get; set; }
        [JsonPropertyName("source")]
        public string source { get; set; }
        [JsonPropertyName("summary")]
        public string summary { get; set; }
        [JsonPropertyName("url")]
        public string url { get; set; }
    }
}
