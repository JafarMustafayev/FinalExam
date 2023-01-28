using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bilet_3.Models
{
    public class DataContext:IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        public DbSet<Position> Positions { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Team> Teams { get; set; }
       
    }
}
