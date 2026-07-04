namespace ChessOnline.API.DTOs
{
    public class UserRegisterDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string Country { get; set; }
        public required DateTime Birthday { get; set; }
    }
}
