namespace ApiDemo.Data.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public bool HasWonNobel { get; set; }
    }
}
