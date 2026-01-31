using Domain;
using Microsoft.AspNetCore.Identity;

namespace AuthDomain
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public virtual ICollection<Book> FavoriteBooks { get; set; } = new List<Book>();
    }
}
