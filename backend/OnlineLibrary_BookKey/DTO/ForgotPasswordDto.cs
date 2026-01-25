using System.ComponentModel.DataAnnotations;

namespace WebApplication25.Models
{
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
