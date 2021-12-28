using ApiDemo.Data.Models;

namespace ApiDemo.Data.Dto
{
    public class DirectorDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public bool HasWonOscar { get; set; }
    }
}
