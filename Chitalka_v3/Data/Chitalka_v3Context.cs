using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chitalka_v3.Models;

namespace Chitalka_v3.Data
{
    public class Chitalka_v3Context : DbContext
    {
        public Chitalka_v3Context (DbContextOptions<Chitalka_v3Context> options)
            : base(options)
        {
        }

        public DbSet<Chitalka_v3.Models.Books> Books { get; set; }

        public DbSet<Chitalka_v3.Models.User> User { get; set; }

        public DbSet<Chitalka_v3.Models.Author> Author { get; set; }

        public DbSet<Chitalka_v3.Models.Centuary> Centuary { get; set; }

        public DbSet<Chitalka_v3.Models.Country> Country { get; set; }

        public DbSet<Chitalka_v3.Models.Genre> Genre { get; set; }

        public DbSet<Chitalka_v3.Models.Image> Image { get; set; }

        public DbSet<Chitalka_v3.Models.Image2> Image2 { get; set; }
    }
}
