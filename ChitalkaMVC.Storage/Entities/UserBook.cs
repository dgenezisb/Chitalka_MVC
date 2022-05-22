namespace ChitalkaMVC.Storage.Entities
{
    public class UserBook
    {
        public string UserId { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
