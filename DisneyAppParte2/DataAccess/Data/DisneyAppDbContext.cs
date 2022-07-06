using DisneyAppParte2.Models;

namespace DisneyAppParte2.DataAccess.Data
{
    public class DisneyAppDbContext : DbContext
    {
        public DbSet<Character> Character { get; set; }
        public DbSet<MovieSerie> MovieSerie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<User> User { get; set; }
        public DisneyAppDbContext(DbContextOptions<DisneyAppDbContext> options) : base(options)
        {

        }

    }
}
