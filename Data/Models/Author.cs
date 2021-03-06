using ApiDemo.Models.Data;

namespace ApiDemo.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public bool HasWonNobel { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
