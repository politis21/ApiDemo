namespace ApiDemo.Data.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public bool HasWonOscar { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
