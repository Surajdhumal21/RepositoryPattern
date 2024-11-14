using Microsoft.EntityFrameworkCore;
using RepositoryPattern.WebAPI.Models;

namespace RepositoryPattern.WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
    }
}
