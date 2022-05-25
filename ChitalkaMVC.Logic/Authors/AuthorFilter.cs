namespace ChitalkaMVC.Logic.Authors
{
    public static class AuthorFilter
    {
        public static bool Filter(AuthorFilterOptions options, Author author)
        {
            if (options.AuthorName != null)
                if (!author.Name.Contains(options.AuthorName, StringComparison.OrdinalIgnoreCase))
                    return false;
            if (options.Countries != null)
            {
                var tmp = options.Countries.Split(';');
                if (!tmp.Contains(author.Country.Name))
                    return false;
            }  
            return true;
        }
    }
}
