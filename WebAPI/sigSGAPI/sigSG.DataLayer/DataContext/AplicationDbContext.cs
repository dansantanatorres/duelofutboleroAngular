using Microsoft.EntityFrameworkCore;
using sigSG.Models;

namespace sigSG.DataLayer.DataContext
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }
    }
}
