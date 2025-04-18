
using Clerk.Net.AspNetCore.Security;
using FinanceBackend.Data.Database;
using FinanceBackend.Endpoints;
using FinanceBackend.Interfaces;
using FinanceBackend.Services;
using Microsoft.EntityFrameworkCore;

namespace FinanceBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(ClerkAuthenticationDefaults.AuthenticationScheme)
                .AddClerkAuthentication( x =>
                {
                    x.Authority = builder.Configuration["Clerk:Authority"]!;
                    x.AuthorizedParty = builder.Configuration["Clerk:AuthorizedParty"]!;
                });
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration["ConnectionStrings:default"] ?? throw new InvalidOperationException("Connection string not found.")));
            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IFinancialDataService, FinancialDataService>();
            builder.Services.AddScoped<ICacheService, CacheService>();
            builder.Services.AddScoped<IFavoriteService, FavoritesService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            builder.Services.AddOpenApi();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
              
            }
            app.MapOpenApi();

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();
            app.RegisterFinancialDataEnpoints();
            app.RegisterUserEndpoints();
         
            app.Run();
        }
    }
}
