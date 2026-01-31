using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Назва книги обов'язкова")]
        [MaxLength(200)]
        public string Title { get; set; }
        [Range(1500, 2026)]
        public int Year { get; set; }
        [MaxLength(200)]
        public string Author { get; set; }
        [Url]
        public string Image { get; set; }
        [Range(0, 5)]
        public int Rating { get; set; }
        public string? Content { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<AuthDomain.ApplicationUser> FavoritedByUsers { get; set; } = new List<AuthDomain.ApplicationUser>();
    }
}
