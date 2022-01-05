using ApiDemo.Data.Dto;
using ApiDemo.Data.Models;

namespace ApiDemo.Data
{
    public class AuthorsRepository
    {
        private AppDbContext _context;

        public AuthorsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorDto authorDto)
        {
            var author = new Author()
            {
                Name = authorDto.Name,
                DateOfBirth = authorDto.DateOfBirth,
                Nationality = authorDto.Nationality,
                HasWonNobel = authorDto.HasWonNobel
            };
            _context.Add(author);
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthors()
        {
            var author = _context.Authors.ToList();
            return author;
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void DeleteAuthorById(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
