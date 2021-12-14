using ApiDemo.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Data.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRealesed { get; set; }
        public DateTime? DateRealesed { get; set; }
        public int? Rate { get; set; }
        public string? Protagonist { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public MovieGenreEnum MovieGenre { get; set; }
        public int DirectorId { get; set; }
    }
}
