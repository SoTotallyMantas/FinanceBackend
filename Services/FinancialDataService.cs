using FinanceBackend.Entities.Finnhub;
using FinanceBackend.Interfaces;
using System.Text.Json;

namespace FinanceBackend.Services
{
    public class FinancialDataService(IConfiguration configuration, IHttpClientFactory httpClientFactory) : IFinancialDataService
    {
        private readonly string _apiKey = configuration["FinnHub:ApiKey"] 
            ?? throw new InvalidOperationException("FinnHub API key is missing.");
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

        public async Task<List<MarketNews>> GetMarketNewsAsync()
        {
            var response = await _httpClient.GetAsync($"https://finnhub.io/api/v1/news?category=general&token={_apiKey}");
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<MarketNews> marketNews = JsonSerializer.Deserialize<List<MarketNews>>(json,options);
                return marketNews;
            }
            else
            {
                return new List<MarketNews>();
            }
        }
        public async Task<List<CompanyNews>> GetCompanyNewsAsync(string symbol)
        {
            DateTime dateTo = DateTime.Today;
            DateTime dateFrom = dateTo.AddMonths(-3);
            string ToStr = dateTo.ToString("yyyy-MM-dd");
            string FromStr = dateFrom.ToString("yyyy-MM-dd");


            var response = await _httpClient.GetAsync($"https://finnhub.io/api/v1/company-news?symbol={symbol}&from={FromStr}&to={ToStr}&token={_apiKey}");
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
               List<CompanyNews> companyNews = JsonSerializer.Deserialize<List<CompanyNews>>(json, options);
                return companyNews;
            }
            else
            {
                return new List<CompanyNews>();
            }
        }
        public async Task<StockPrice> GetStockPriceAsync(string symbol)
        {
            var response = await _httpClient.GetAsync($"https://finnhub.io/api/v1/quote?symbol={symbol}&token={_apiKey}");
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                    
                  
                };
                
                    StockPrice stockPrice = JsonSerializer.Deserialize<StockPrice>(json, options);
                    return stockPrice;
               
            }
            else
            {
                return new StockPrice();
            }
        } 
       
        public async Task<StockMetric> GetStockMetricAsync(string symbol)
        {
            var response = await _httpClient.GetAsync($"https://finnhub.io/api/v1/stock/metric?symbol={symbol}&metric=all&token={_apiKey}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                using var document = JsonDocument.Parse(json);
                var metricElement = document.RootElement.GetProperty("metric");
                var metricJson = metricElement.GetRawText();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                StockMetric metric = JsonSerializer.Deserialize<StockMetric>(metricJson,options);
                return metric;
            }
            else
            {
                return new StockMetric();
            }
        }
        public async Task<List<TradeSymbol>> GetStockSymbolsAsync()
        {
                // using static exchange US Dev
                var response = await _httpClient.GetAsync($"https://finnhub.io/api/v1/stock/symbol?exchange=US&token={_apiKey}");
            if (response.IsSuccessStatusCode)
            {
                var json =  await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<TradeSymbol> Symbols = JsonSerializer.Deserialize<List<TradeSymbol>>(json,options);

                    return Symbols;
               
            }
            else
            {
                return new List<TradeSymbol>();
            }
            }
        }
}
