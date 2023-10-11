using Microsoft.EntityFrameworkCore;
using Startup.Data.Entities;

namespace Startup.Data
{
    public class StartupDBContext : DbContext
    {
        public StartupDBContext(DbContextOptions<StartupDBContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}