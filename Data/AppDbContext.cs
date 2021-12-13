using ApiDemo.Data.Models;
using ApiDemo.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Code First
        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(b => b.MovieGenre)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
