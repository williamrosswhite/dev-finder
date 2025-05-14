    public class AuthDto
    {
        public string ActionType { get; set; } = null!; // "login" or "signup"
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }