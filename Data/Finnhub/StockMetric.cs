using System.Text.Json.Serialization;

namespace FinanceBackend.Entities.Finnhub
{

    public class StockMetric
    {

        [JsonPropertyName("52WeekHigh")]
        public double? Week52High { get; set; }

        [JsonPropertyName("52WeekLow")]
        public double? Week52Low { get; set; }

        [JsonPropertyName("10DayAverageTradingVolume")]
        public double? AvgVolume10Day { get; set; }

        [JsonPropertyName("dividendGrowthRate5Y")]
        public double? DividendGrowth5Y { get; set; }

        [JsonPropertyName("dividendYieldIndicatedAnnual")]
        public double? DividendYieldIndicated { get; set; }

        [JsonPropertyName("currentDividendYieldTTM")]
        public double? DividendYieldTTM { get; set; }

        [JsonPropertyName("epsAnnual")]
        public double? EpsAnnual { get; set; }

        [JsonPropertyName("epsTTM")]
        public double? EpsTTM { get; set; }

        [JsonPropertyName("epsGrowthTTMYoy")]
        public double? EpsGrowthTTMYoy { get; set; }

        [JsonPropertyName("epsGrowth5Y")]
        public double? EpsGrowth5Y { get; set; }

        [JsonPropertyName("grossMarginTTM")]
        public double? GrossMarginTTM { get; set; }

        [JsonPropertyName("operatingMarginTTM")]
        public double? OperatingMarginTTM { get; set; }

        [JsonPropertyName("netProfitMarginTTM")]
        public double? NetProfitMarginTTM { get; set; }

        [JsonPropertyName("roiTTM")]
        public double? RoiTTM { get; set; }

        [JsonPropertyName("roaTTM")]
        public double? RoaTTM { get; set; }

        [JsonPropertyName("roeTTM")]
        public double? RoeTTM { get; set; }

        [JsonPropertyName("revenueGrowthTTMYoy")]
        public double? RevenueGrowthTTMYoy { get; set; }

        [JsonPropertyName("revenueGrowth5Y")]
        public double? RevenueGrowth5Y { get; set; }
    }
}
