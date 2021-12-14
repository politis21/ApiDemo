using ApiDemo.Data.Dto;

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

        public void AddMovie(MovieDto movieDto)
        {
            var movie = new Movie()
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                DateRealesed = movieDto.DateRealesed,
                CoverUrl = movieDto.CoverUrl,
                IsRealesed = !movieDto.IsRealesed,
                Rate = movieDto.Rate,
                DateAdded = movieDto.DateAdded,
                MovieGenre = movieDto.MovieGenre,
                DirectorId = movieDto.DirectorId
            };

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

        public List<Movie> GetMoviesSortedByName ()
        {
            var sortedByName = _context.Movies.OrderBy(x => x.Title).ToList();
            return sortedByName;
        }
    }
}
