namespace ApiDemo.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRealesed { get; set; }
        public DateTime? DateRealesed { get; set; }
        public int? Rate { get; set; }
        public string? Protagonist { get; set; }
        public string? Director { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
