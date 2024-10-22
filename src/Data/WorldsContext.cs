using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class WorldsContext : DbContext
    {
        public WorldsContext(DbContextOptions<WorldsContext> options) : base(options) { }
        public DbSet<Models.Team> Teams { get; set; }
        public DbSet<Models.Match> Matches { get; set; }
    }
}