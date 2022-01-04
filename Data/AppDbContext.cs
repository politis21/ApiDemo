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
        public DbSet<Director> Directors { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(b => b.MovieGenre)
                .HasConversion<int>()
                .IsRequired();


            modelBuilder.Entity<Director>()
                .HasMany<Movie>(g => g.Movies);

            modelBuilder.Entity<Author>()
                .HasMany<Book>(g => g.Books);
        }
    }
}
