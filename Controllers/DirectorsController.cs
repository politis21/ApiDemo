using ApiDemo.Data;
using ApiDemo.Data.Dto;
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

        [HttpDelete("delete-director-by-id/{id}")]
        public IActionResult DeleteDirectorById(int id)
        {
            _repository.DeleteDirectorById(id);
            return Ok();
        }
    }
}
