using ApiDemo.Data;
using ApiDemo.Data.Dto;
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

        [HttpGet(Name = "get-all-books")]
        public IActionResult GetAllBooks()
        {
            var books = _repository.GetBooks();
            return Ok(books);
        }

        [HttpPost(Name = "add-book")]
        public IActionResult AddBook([FromBody] BookDto bookDto)
        {
            _repository.AddBook(bookDto);
            return Ok();
        }

        [HttpGet(Name = "get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _repository.GetBookById(id);
            return Ok(book);
        }

        [HttpPut(Name = "update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, Book book)
        {
            //var entity = _repository.GetBookById(id);
            //if (entity is null) return NotFound("...was not found in db");
            //var updatedBook...

            var updatedBook = _repository.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _repository.DeleteBookById(id);
            return Ok();
        }
    }
}
