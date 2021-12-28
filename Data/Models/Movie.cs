using ApiDemo.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRealesed { get; set; }
        public DateTime? DateRealesed { get; set; }
        [Range(0, 10)]
        public int? Rate { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public MovieGenreEnum MovieGenre { get; set; }

        public int DirectorId { get; set; }
        public Director? Director { get; set; }

    }
}
