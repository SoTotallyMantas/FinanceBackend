using FinanceBackend.Interfaces;
using FinanceBackend.Services;
using Microsoft.AspNetCore.Builder;
using NodaTime;
using System.Reflection.Metadata.Ecma335;

namespace FinanceBackend.Endpoints
{
    public static class FinancialDataEnpoints
    {
        public static void RegisterFinancialDataEnpoints(this WebApplication app)
        {
            var RouteGrouping = app.MapGroup("/finance");

            RouteGrouping.MapGet("/StockMetric", GetMetric);
            RouteGrouping.MapGet("/StockPrice", GetStockPrice);
            RouteGrouping.MapGet("/Symbols", GetSymbols);
            RouteGrouping.MapGet("/MarketNews", GetMarketNews);
            RouteGrouping.MapGet("/CompanyNews", GetCompanyNews);

            static async Task<IResult> GetMarketNews(ICacheService cacheService)
            {
                var data = await cacheService.GetCacheMarketNewsAsync();
                return Results.Ok(data);
            };
            static async Task<IResult> GetCompanyNews(string symbol, ICacheService cacheService)
            {
                var data = await cacheService.GetCacheCompanyNewsAsync(symbol);
                return Results.Ok(data);
            };
            static async Task<IResult> GetMetric(string symbol, ICacheService cacheService)
            {
                var data = await cacheService.GetCacheStockMetricAsync(symbol);
                return Results.Ok(data);
            };
            static async Task<IResult> GetStockPrice(string symbol, ICacheService cacheService)
            {
                var data = await cacheService.GetCacheStockPriceAsync(symbol);
                return Results.Ok(data);
            };
            static async Task<IResult> GetSymbols(ICacheService cacheService)
            {
               
                var data = await cacheService.GetCacheStockSymbolsAsync();
                return Results.Ok(data);
            };



        }
    }
}
