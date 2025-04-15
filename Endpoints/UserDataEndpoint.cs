

using Clerk.Net.Client.Models;
using FinanceBackend.Data.Database;
using FinanceBackend.Data.DTO;
using FinanceBackend.Interfaces;
using FinanceBackend.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;

namespace FinanceBackend.Endpoints
{
    public static class UserDataEndpoint
    {

        public static void RegisterUserEndpoints(this WebApplication app)
        {
            var RouteGrouping = app.MapGroup("/user");

            RouteGrouping.MapGet("/favorites", GetFavorites);
            RouteGrouping.MapPost("/favorites",PostFavorites);
            RouteGrouping.MapDelete("/favorites", DeleteFavorites);
            RouteGrouping.RequireAuthorization();

            static async Task<IResult> GetFavorites(ClaimsPrincipal user,IFavoriteService favoriteService)
            {

                var userId = user.Identity.Name;
                List<UserFavorites> userFavorites = favoriteService.GetUserFavorites(userId);
                
                return Results.Ok(UserFavoritesDTO.ToDTOList(userFavorites));

            }
            static async Task<IResult> PostFavorites(ClaimsPrincipal user, IFavoriteService favoriteService,string symbol)
            {

                var userId = user.Identity.Name;
               return await favoriteService.PostUserFavoritesAsync(userId, symbol);
               

            }
            static async Task<IResult>  DeleteFavorites(ClaimsPrincipal user, IFavoriteService favoriteService, string symbol)
            {

                var userId = user.Identity.Name;
                return await favoriteService.DeleteUserFavoritesAsync(userId, symbol);
               

            }
        }
    }
    
}
