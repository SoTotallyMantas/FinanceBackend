namespace FinanceBackend.Data.Database
{
    public class UserFavorites
    {
        public Guid? Guid { get; set; }
        public string? UserId {  get; set; }
        public  string Symbol { get; set; }
        public bool Favorites { get; set; }
    }
}
