using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.Data.Models
{
    public class category
    {
        public int id {
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
        public List<books> cBooks{   set;   get;}
    }
}
