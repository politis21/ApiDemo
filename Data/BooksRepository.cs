using ApiDemo.Data.Dto;
using ApiDemo.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiDemo.Data
{
    public class BooksRepository
    {
        private AppDbContext _context;

        public BooksRepository(AppDbContext context)
        {
            //Dependency Injection
            _context = context;
        }

        public void AddBook(BookDto bookDto)
        {
            var book = new Book()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                IsRead = bookDto.IsRead,
                DateRead = bookDto.DateRead,
                Rate = bookDto.Rate,
                Genre = bookDto.Genre,
                CoverUrl = bookDto.CoverUrl,
                DateAdded = bookDto.DateAdded,
                AuthorId = bookDto.AuthorId
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public Book UpdateBookById(int id, BookDto book)
        {
            var entity = _context.Books.Find(id);
            if (entity is not null)
            {
                entity.Title = book.Title;
                entity.Description = book.Description;
                entity.IsRead = book.IsRead;
                entity.Genre = book.Genre;
                entity.DateRead = book.DateRead;
                entity.DateAdded = book.DateAdded;
                entity.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            }
        
            return entity;
        }

        public void DeleteBookById(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Book>> SearchBook(string title)
        {
            IQueryable<Book> query = _context.Books;

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(e => e.Title.Contains(title));
            }

            return await query.ToListAsync();
        }
    }
}
