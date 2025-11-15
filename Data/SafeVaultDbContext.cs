using Microsoft.EntityFrameworkCore;
using SafeVaultSecurityProject.Models;

namespace SafeVaultSecurityProject.Data
{
    public class SafeVaultDbContext : DbContext
    {
        public SafeVaultDbContext(DbContextOptions<SafeVaultDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
