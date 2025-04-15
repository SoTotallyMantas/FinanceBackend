using FinanceBackend.Entities.Finnhub;

namespace FinanceBackend.Interfaces
{
    public interface ICacheService
    {

        Task<List<TradeSymbol>> GetCacheStockSymbolsAsync();
        Task<StockMetric> GetCacheStockMetricAsync(string symbol);
        Task<StockPrice> GetCacheStockPriceAsync(string symbol);
        Task<List<MarketNews>> GetCacheMarketNewsAsync();
        Task<List<CompanyNews>> GetCacheCompanyNewsAsync(string symbol);
    }
}
