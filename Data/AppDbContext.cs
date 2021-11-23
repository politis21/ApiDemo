using ApiDemo.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books {get; set;}
    }
}
