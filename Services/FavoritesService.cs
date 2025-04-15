using FinanceBackend.Data.Database;
using FinanceBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceBackend.Services
{
    public class FavoritesService : IFavoriteService
    {
        private ApplicationDbContext _context;
        public FavoritesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public  List<UserFavorites> GetUserFavorites(string UserId)
        {
            List<UserFavorites> Favorites = _context.userFavorites.Where(p => p.UserId == UserId).ToList();
            if (Favorites.Count > 0)
            {
                return Favorites;
            }
            else
            {
                return [];
            }
        }
        public async Task<IResult> PostUserFavoritesAsync(string user, string symbol)
        {
            UserFavorites userFavorite = new(){
                Favorites = true,
                Symbol = symbol,
                UserId = user
            };
            _context.Add(userFavorite);
           await _context.SaveChangesAsync();
            return Results.Created();
        }

        public async Task<IResult> DeleteUserFavoritesAsync(string user, string symbol)
        {
            try
            {
                var favorite = await _context.userFavorites.FirstOrDefaultAsync(uF => uF.Symbol == symbol && uF.UserId == user);

                if (favorite is null)
                {
                    return Results.NotFound();
                }
                else
                {
                    _context.Remove(favorite);
                    await _context.SaveChangesAsync();
                }
                return Results.Ok("Favorite Deleted");
               
            }
            catch(Exception error)
            {
                Console.WriteLine("Exception: ", error.Message);
                return Results.InternalServerError(error.Message);
            }
        }
    }
}
