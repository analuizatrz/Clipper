namespace Clipper.Services.Dtos
{
    public class BookDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long AuthorId { get; set; }
        public string Description { get; set; }
        public int Edition { get; set; }
        public int Year { get; set; }
    }
}