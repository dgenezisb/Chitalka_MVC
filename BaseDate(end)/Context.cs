using BaseDate_end_.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseDate_end_
{

    
        public class Context : DbContext
        {
            public Context(DbContextOptions<Context> options) : base(options)
            {

            }
        public DbSet<Century> Centuries { get; set; }
            public DbSet<Country> Countries { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Book> Books { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Genre> Genres { get; set; }
            public DbSet<Note> Notes { get; set; }
        }
    }
