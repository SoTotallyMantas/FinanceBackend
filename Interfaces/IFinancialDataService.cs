using FinanceBackend.Entities.Finnhub;

namespace FinanceBackend.Interfaces
{
    public interface IFinancialDataService
    {
        Task<List<TradeSymbol>> GetStockSymbolsAsync();
        Task<StockMetric> GetStockMetricAsync(string symbol);
        Task<StockPrice> GetStockPriceAsync(string symbol);
        Task<List<MarketNews>> GetMarketNewsAsync();
        Task<List<CompanyNews>> GetCompanyNewsAsync(string symbol);
        
    }
}
