using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Collections.Generic.IEnumerable;

namespace Prr_stakan.Data.Models
{
    public class books
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
        public int categoryID
        {
            set;
            get;
        }
        public int year
        {
            set;
            get;
        }
        public virtual category Category
        {
            set;
            get;
        }
    }
}
