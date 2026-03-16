namespace UsersWebApiMoq16_03_2026.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // ⚠️ In real apps store hashed passwords!
    }
}
