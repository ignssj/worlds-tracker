using Microsoft.EntityFrameworkCore;
using worlds_tracker.src.Models;

namespace worlds_tracker.src.Data
{
    public class WorldsContext : DbContext
    {
        public WorldsContext(DbContextOptions<WorldsContext> options) : base(options) { }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}