namespace OnlineLibrary_BookKey.DTO.BookUser
{
    public class UserLibraryDto
    {
        // Дані з таблиці Book
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Author { get; set; }
        public string? Image { get; set; }

        public bool IsFinished { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
