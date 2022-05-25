namespace ChitalkaMVC.Models
{
    public class EmailConfirmationViewModel
    {
        public string Email { get; set; }
        public string? Result { get; set; }
        public int? ConfirmationCode { get; set; }
    }
}
