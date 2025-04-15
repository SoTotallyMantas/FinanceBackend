using System.Text.Json.Serialization;

namespace FinanceBackend.Entities.Finnhub
{
    //  Stock Symbols // 
    public class TradeSymbol
    {

        public string Symbol { get; set; }
        public string Description { get; set; }
    }
}
