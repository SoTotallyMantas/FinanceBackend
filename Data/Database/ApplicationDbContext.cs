using Microsoft.EntityFrameworkCore;

namespace FinanceBackend.Data.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<UserFavorites> userFavorites { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserFavorites>()
                .HasKey(uf => uf.Guid);
            modelBuilder.Entity<UserFavorites>()
                .Property(p => p.Guid)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserFavorites>()
                .HasIndex(e => new { e.UserId, e.Symbol })
                .IsUnique();
        }
    }
}
