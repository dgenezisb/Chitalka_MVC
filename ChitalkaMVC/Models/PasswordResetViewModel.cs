namespace ChitalkaMVC.Models
{
    public class PasswordResetViewModel
    {
        public string Email { get; set; }
        public int ConfirmationCode { get; set; }
        public string? Result { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
