using ApiDemo.Data;
using ApiDemo.Data.Dto;
using ApiDemo.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorsController : ControllerBase
    {
        private AuthorsRepository _repository;
        public AuthorsController(AuthorsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(Name = "add-author")]
        public IActionResult AddAuthor([FromBody] AuthorDto author)
        {
            _repository.AddAuthor(author);
            return Ok();
        }

        [HttpGet(Name = "get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            var author = _repository.GetAllAuthors();
            return Ok(author);
        }

        [HttpGet(Name = "get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _repository.GetAuthorById(id);
            return Ok(author);
        }

        [HttpPut(Name = "update-author-by-id/{id}")]
        public IActionResult UpdateAuthorById(int id, AuthorDto author)
        {
            var updatedAuthor = _repository.UpdateAuthorById(id, author);
            return Ok(updatedAuthor);
        }

        [HttpDelete("delete-author-by-id/{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _repository.DeleteAuthorById(id);
            return Ok();
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<IEnumerable<Author>>> SearchAuthor(string name)
        {
            try
            {
                var result = await _repository.SearchAuthor(name);

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
