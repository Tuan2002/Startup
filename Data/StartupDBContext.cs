using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Startup.Models;

namespace Startup.Data
{
    public class StartupDBContext : DbContext
    {
        public StartupDBContext(DbContextOptions<StartupDBContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Post> Post { get; set; }
    }
}