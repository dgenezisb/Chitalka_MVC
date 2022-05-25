namespace ChitalkaMVC.Logic.Books
{
    public class BookFilterOptions
    {
        public string? AuthorName { get; set; }
        public string? Title { get; set; }
        public int[]? GenreIds { get; set; }
        public int[]? CenturyIds { get; set; }
    }
}
