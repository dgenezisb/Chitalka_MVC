using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Chitalka.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Books> books
        {
            get;
            set;
        }
        public DbSet<Category> category
        {
            get;
            set;
        }
        public DbSet<User> user
        {
            get;
            set;
        }
    }
}