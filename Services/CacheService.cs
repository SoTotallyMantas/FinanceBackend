using FinanceBackend.Entities.Finnhub;
using FinanceBackend.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FinanceBackend.Services
{
    public class CacheService(IFinancialDataService financialDataService, IMemoryCache MemoryCache) : ICacheService
    {
        private readonly IMemoryCache _memoryCache = MemoryCache;
        private readonly IFinancialDataService _financialDataService = financialDataService;
       
        public async Task<List<TradeSymbol>> GetCacheStockSymbolsAsync()
        {
            const string cacheKey = "StockSymbols";

           if(!_memoryCache.TryGetValue(cacheKey, out List<TradeSymbol> Symbols))
            {
                Symbols = await _financialDataService.GetStockSymbolsAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromDays(1))
                    .SetAbsoluteExpiration(TimeSpan.FromDays(2))
                    .SetPriority(CacheItemPriority.Normal);
                if(Symbols is not null)
                {
                    _memoryCache.Set(cacheKey, Symbols, cacheEntryOptions);
                }
            }
            if (Symbols is not null)
            {
                return Symbols;
            }

            return [];
        }
        public async Task<StockMetric> GetCacheStockMetricAsync(string symbol)
        {
             string cacheKey = $"StockMetric:{symbol}";

            if (!_memoryCache.TryGetValue(cacheKey, out StockMetric StockMetric))
            {
               StockMetric = await _financialDataService.GetStockMetricAsync(symbol);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromDays(1))
                    .SetAbsoluteExpiration(TimeSpan.FromDays(2))
                    .SetPriority(CacheItemPriority.Normal);
                if (StockMetric is not null)
                {
                    _memoryCache.Set(cacheKey, StockMetric, cacheEntryOptions);
                }

            }
            if (StockMetric is not null)
            {
                return StockMetric;
            }

            return null;
        }
        public async Task<StockPrice> GetCacheStockPriceAsync(string symbol) 
        {
            string cacheKey = $"StockPrice:{symbol}";

            if (!_memoryCache.TryGetValue(cacheKey, out StockPrice stockPrice))
            {
                stockPrice= await _financialDataService.GetStockPriceAsync(symbol);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                    .SetPriority(CacheItemPriority.Normal);
                if (stockPrice is not null)
                {
                    _memoryCache.Set(cacheKey, stockPrice, cacheEntryOptions);
                }

            }
            if (stockPrice is not null)
            {
                return stockPrice;
            }

            return null;
        }
        public async Task<List<MarketNews>> GetCacheMarketNewsAsync()
        {
            const string cacheKey = "MarketNews";

            if (!_memoryCache.TryGetValue(cacheKey, out List<MarketNews> marketNews))
            {
                marketNews = await _financialDataService.GetMarketNewsAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10))
                    .SetPriority(CacheItemPriority.Normal);
                if (marketNews is not null)
                {
                    _memoryCache.Set(cacheKey, marketNews, cacheEntryOptions);
                }
            }
            if (marketNews is not null)
            {
                return marketNews;
            }

            return [];
        }
        public async Task<List<CompanyNews>> GetCacheCompanyNewsAsync(string symbol)
        {
            string cacheKey = $"CompanyNews:{symbol}";

            if (!_memoryCache.TryGetValue(cacheKey, out List<CompanyNews> companyNews))
            {
                companyNews = await _financialDataService.GetCompanyNewsAsync(symbol);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10))
                    .SetPriority(CacheItemPriority.Normal);
                if (companyNews is not null)
                {
                    _memoryCache.Set(cacheKey, companyNews, cacheEntryOptions);
                }
            }
            if (companyNews is not null)
            {
                return companyNews;
            }

            return [];
        }
    }
}
