namespace ChessOnline.API.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
