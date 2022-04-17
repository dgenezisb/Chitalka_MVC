using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chitalka.Models
{
    public class User
    {
        
        public int id
        {
            get;
            set;
        }
        public string usrName
        {
            get;
            set;
        }
        public string pswrd
        {
            get;
            set;
        }
        public bool ifAdmin
        {
            get;
            set;
        }
        public string mail
        {
            get;
            set;
        }
        public string ico
        {
            get;
            set;
        }
    }
}