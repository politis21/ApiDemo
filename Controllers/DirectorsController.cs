using ApiDemo.Data;
using ApiDemo.Data.Dto;
using ApiDemo.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DirectorsController : ControllerBase
    {
        private DirectorsRepository _repository;
        public DirectorsController(DirectorsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(Name = "add-director")]
        public IActionResult AddDirector([FromBody] DirectorDto director)
        {
            _repository.AddDirector(director);
            return Ok();
        }

        [HttpGet(Name = "get-all-directors")]
        public IActionResult GetAllDirectors()
        {
            var director = _repository.GetAllDirectors();
            return Ok(director);
        }

        [HttpGet(Name = "get-director-by-id/{id}")]
        public IActionResult GetDirectorById(int id)
        {
            var director = _repository.GetDirectorById(id);
            return Ok(director);
        }

        [HttpPut(Name = "update-director-by-id/{id}")]
        public IActionResult UpdateDirectorById(int id, DirectorDto director)
        {
            var updatedDirector = _repository.UpdateDirectorById(id, director);
            return Ok(updatedDirector);
        }

        [HttpDelete("delete-director-by-id/{id}")]
        public IActionResult DeleteDirectorById(int id)
        {
            _repository.DeleteDirectorById(id);
            return Ok();
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<IEnumerable<Director>>> SearchDirector(string name)
        {
            try
            {
                var result = await _repository.SearchDirector(name);

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
