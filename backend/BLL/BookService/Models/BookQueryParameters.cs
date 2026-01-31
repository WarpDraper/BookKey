namespace OnlineLibrary_BookKey.DTO.Book
{
    public class BookQueryParameters
    {
        public string? SearchTerm { get; set; } // Пошук по назві
        public string? Author { get; set; }     // Фільтр по автору
        public int PageNumber { get; set; } = 1; // Яка сторінка
        public int PageSize { get; set; } = 10;  // Скільки книг на сторінці

        public string? SortBy { get; set; }
    }
}
