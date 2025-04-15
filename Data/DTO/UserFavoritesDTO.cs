using FinanceBackend.Data.Database;

namespace FinanceBackend.Data.DTO
{
    public class UserFavoritesDTO
    {
        public string Symbol { get; set; }
        public bool Favorites { get; set; }

        public static UserFavoritesDTO ToDTO(UserFavorites favorite)
        {
            return new UserFavoritesDTO
            {
                Symbol = favorite.Symbol,
                Favorites = favorite.Favorites,
            };

        }

        public static List<UserFavoritesDTO> ToDTOList(List<UserFavorites> favorites)
        {
            return favorites.Select(ToDTO).ToList();

        }


    }
}
