namespace Shopp5.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Mã hóa mật khẩu
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
