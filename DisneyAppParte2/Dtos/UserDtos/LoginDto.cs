using System.ComponentModel.DataAnnotations;

namespace DisneyAppParte2.Dtos.UserDtos
{
    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }
    }
}
