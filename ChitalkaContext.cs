using ChitalkaMVC.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChitalkaMVC.Storage
{
    public class ChitalkaContext : DbContext
    {
        public ChitalkaContext(DbContextOptions<ChitalkaContext> options) : base(options)
        {
        }

        public DbSet<Century> Centuries { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
