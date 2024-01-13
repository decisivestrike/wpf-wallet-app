using Microsoft.EntityFrameworkCore;

namespace Coinbase
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Log> Logs { get; set; } = null!;

        public Context() 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=coinbase;username=postgres;password=1111");
        }
    }
}
