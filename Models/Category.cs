using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chitalka.Models
{
    public class Category
    {
        public int id
        {
            set;
            get;
        }
        public string categoryName
        {
            set;
            get;
        }
        public string description
        {
            set;
            get;
        }
        public string catName
        {
            set;
            get;
        }
        public List<Books> cBooks { set; get; }
    }
}