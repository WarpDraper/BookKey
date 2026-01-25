using System.ComponentModel.DataAnnotations;

namespace WebApplication25.Models
{
    public class RefreshTokenDto
    {
        [Required]
        public string RefreshToken { get; set; }
        [Required]
        public string Token {  get; set; }
    }
}
