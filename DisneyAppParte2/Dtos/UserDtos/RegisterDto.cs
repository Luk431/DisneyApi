using System.ComponentModel.DataAnnotations;

namespace DisneyAppParte2.Dtos.UserDtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
