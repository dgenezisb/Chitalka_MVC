using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chitalka.Models
{
    public class Books
    {
        public int id
        {
            set;
            get;
        }
        public string bookInside
        {
            set;
            get;
        }
        public string bookName
        {
            set;
            get;
        }
        public string descriprionBook
        {
            set;
            get;
        }
        public string img
        {
            set;
            get;
        }
        public int categoryName
        {
            set;
            get;
        }
        public int year
        {
            set;
            get;
        }
        public string author
        {
            get;
            set;
        }
        public virtual Category category
        {
            set;
            get;
        }
    }
}