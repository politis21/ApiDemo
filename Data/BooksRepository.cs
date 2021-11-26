using ApiDemo.Models.Data;

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

        public void AddBook(Book book)
        {
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

    }
}
