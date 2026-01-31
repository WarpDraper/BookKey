using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary_BookKey.DTO.Book
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Назва обов'язкова")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Range(1000, 2026)]
        public int Year { get; set; }

        public string? Author { get; set; }

        [Url(ErrorMessage = "Це має бути посилання")]
        public string? Image { get; set; }

        [MaxLength(2000)]
        public string? Content { get; set; }
    }
}
