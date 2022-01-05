using ApiDemo.Data;
using ApiDemo.Data.Dto;
using ApiDemo.Data.Models;
using ApiDemo.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MoviesController: ControllerBase
    {
        private MoviesRepository _repository;

        public MoviesController(MoviesRepository repository)
        {
            //Dependency Injection
            _repository = repository;
        }

        [HttpGet(Name = "get-all-movies")]
        public IActionResult GetAllMovies()
        {
            var movies = _repository.GetAllMovies();
            return Ok(movies);
        }

        [HttpPost(Name = "add-movie")]
        public IActionResult AddMovie([FromBody] MovieDto movie)
        {
            _repository.AddMovie(movie);
            return Ok();
        }

        [HttpGet(Name = "get-movie-by-id/{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _repository.GetMovieById(id);
            return Ok(movie);
        }

        [HttpGet(Name = "get-movie-sorted-by-name")]
        public IActionResult GetMoviesSortedByName()
        {
            var sortedByName = _repository.GetMoviesSortedByName();
            return Ok(sortedByName);
        }

        [HttpDelete("delete-movie-by-id/{id}")]
        public IActionResult DeleteMovieById(int id)
        {
            _repository.DeleteMovieById(id);
            return Ok();
        }

        [HttpPut(Name = "update-movie-by-id/{id}")]
        public IActionResult UpdateMovieById(int id, Movie movie)
        {
            var updatedMovie = _repository.UpdateMovieById(id, movie);
            return Ok(updatedMovie);
        }

        [HttpGet("search/{title}")]
        public async Task<ActionResult<IEnumerable<Movie>>> SearchMovie(string title)
        {
            try
            {
                var result = await _repository.SearchMovie(title);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
