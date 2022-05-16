namespace ChitalkaMVC.Storage.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book>? Books { get; set; }
    }
}
