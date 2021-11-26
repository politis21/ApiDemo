using ApiDemo.Data;
using ApiDemo.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BooksController: ControllerBase
    {
        private BooksRepository _repository;

        public BooksController(BooksRepository repository)
        {
            //Dependency Injection
            _repository = repository;
        }

        [HttpPost(Name = "get-all-books")]
        public IActionResult GetAllBooks()
        {
            var books = _repository.GetBooks();
            return Ok(books);
        }

        [HttpPost(Name = "add-book")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _repository.AddBook(book);
            return Ok();
        }

        [HttpGet(Name = "get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _repository.GetBookById(id);
            return Ok(book);
        }
    }
}
