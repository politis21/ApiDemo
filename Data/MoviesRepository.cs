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

        public List<Movie> GetAllMovies()
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

        public Movie UpdateMovieById(int id, Movie movie)
        {
            var entity = _context.Movies.Find(id);
            if (entity != null)
            {
                entity.Title = movie.Title;
                entity.Description = movie.Description;
                entity.IsRealesed = movie.IsRealesed;
                entity.DateRealesed = movie.DateRealesed;
                entity.Rate = movie.Rate;
                entity.CoverUrl = movie.CoverUrl;
                entity.DateAdded = movie.DateAdded;
                entity.MovieGenre = movie.MovieGenre;
                entity.DirectorId = movie.DirectorId;
                //entity.Director = movie.Director;
                _context.SaveChanges();
            }
            return entity;
        }
    }
}