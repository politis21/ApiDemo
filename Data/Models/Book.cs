using ApiDemo.Data.Models;

namespace ApiDemo.Models.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string? Genre { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
