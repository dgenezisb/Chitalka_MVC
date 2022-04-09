using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan.Data.Models
{
    public class years
    {
        public int year
        {
            set;
            get;
        }
        public List<books> yBooks { set; get; }
    }
}