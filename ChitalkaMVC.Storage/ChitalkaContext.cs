using ChitalkaMVC.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChitalkaMVC.Storage
{
    public class ChitalkaContext : DbContext
    {
        public ChitalkaContext(DbContextOptions<ChitalkaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBook>().HasKey(i => new { i.UserId, i.BookId });
        }

        public DbSet<Century> Centuries { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<UserBook> UserBook { get; set; }

    }
}
