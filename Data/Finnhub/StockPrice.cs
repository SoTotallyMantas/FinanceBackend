using System.Text.Json.Serialization;

namespace FinanceBackend.Entities.Finnhub
{
    // Stock and ETF Price for the day //
    public class StockPrice
    {

        [JsonPropertyName("c")]
        public decimal? CurrentPrice { get; set; }
        [JsonPropertyName("d")]
        public decimal? Change { get; set; }
        [JsonPropertyName("dp")]
        public decimal? PercentChange { get; set; }
        [JsonPropertyName("h")]
        public decimal? HighPrice { get; set; }
        [JsonPropertyName("l")]
        public decimal? LowPrice { get; set; }
        [JsonPropertyName("o")]
        public decimal? OpenPrice { get; set; }
        [JsonPropertyName("pc")]
        public decimal? PreviousClosePrice { get; set; }

    }
}
