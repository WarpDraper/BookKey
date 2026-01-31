namespace OnlineLibrary_BookKey.DTO.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Author { get; set; }
        public int Year { get; set; }
        public string? ImageUrl { get; set; }
        public double Rating { get; set; }
        public string? Description { get; set; }
    }
}
