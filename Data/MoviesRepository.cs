namespace ApiDemo.Data.Models
{
    public class MoviesRepository
    {
        private AppDbContext _context;

        public MoviesRepository(AppDbContext context)
        {
            //Dependency Injection
            _context = context;
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public List<Movie> GetMovies()
        {
            var movie = _context.Movies.ToList();
            return movie;
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void DeleteMovieById(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
