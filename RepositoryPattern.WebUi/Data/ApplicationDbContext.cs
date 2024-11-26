using Microsoft.EntityFrameworkCore;
using RepositoryPattern.WebUi.Models;

namespace RepositoryPattern.WebUi.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Item>? Items { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
