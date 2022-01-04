using ApiDemo.Data;
using ApiDemo.Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorsController : ControllerBase
    {
        private AuthorsController _repository;
        public AuthorsController(AuthorsController repository)
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

        [HttpDelete("delete-author-by-id/{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _repository.DeleteAuthorById(id);
            return Ok();
        }
    }
}
