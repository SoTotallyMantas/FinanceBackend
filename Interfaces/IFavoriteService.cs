using FinanceBackend.Data.Database;

namespace FinanceBackend.Interfaces
{
    internal interface IFavoriteService
    {
        Task<IResult> DeleteUserFavoritesAsync(string user, string symbol);
        List<UserFavorites> GetUserFavorites(string userId);
        Task<IResult> PostUserFavoritesAsync(string userId, string symbol);
    }
}