using ApiDemo.Data;
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

        [HttpPost(Name = "get-all-movies")]
        public IActionResult GetAllMovies()
        {
            var movies = _repository.GetMovies();
            return Ok(movies);
        }

        [HttpPost(Name = "add-movie")]
        public IActionResult AddMovie([FromBody] Movie movie)
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
    }
}
