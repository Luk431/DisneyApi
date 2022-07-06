namespace DisneyAppParte2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte [] PasswordHash { get; set; }
        public byte [] PasswordSalt { get; set; }
    }
}
