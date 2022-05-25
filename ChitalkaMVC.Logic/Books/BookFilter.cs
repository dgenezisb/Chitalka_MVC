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
            if (options.CenturyIds != null)
                if (!options.CenturyIds.Contains(book.CenturyId))
                    return false;
            if (options.GenreIds != null)
            {
                foreach (var genre in book.Genres)
                    if (options.GenreIds.Contains(genre.Id))
                        return true;
                return false;
            }
            return true;
        }
    }
}
