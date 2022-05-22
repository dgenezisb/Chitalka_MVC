namespace ChitalkaMVC.Logic.Books
{
    public static class BookFilter
    {
        public static bool Filter(BookFilterOptions options, Book book)
        {
            if (options.AuthorName != null)
                if (!book.Author.Name.Contains(options.AuthorName, StringComparison.OrdinalIgnoreCase))
                    return false;
            if (options.Title != null)
                if (!book.Name.Contains(options.Title, StringComparison.OrdinalIgnoreCase))
                    return false;
            if (options.GenreIds != null)
            {
                var tmp = 0;
                foreach (var genre in book.Genres)
                    if (options.GenreIds.Contains(genre.Id))
                        tmp++;
                if (tmp > 0)
                    return true;
                else
                    return false;
            }
            return true;
        }
    }
}
