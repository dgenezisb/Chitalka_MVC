namespace ChitalkaMVC.Models
{
    public class ManageUserPasswordViewModel
    {
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Result { get; set; }
    }
}
