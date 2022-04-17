using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Chitalka.Models
{
    public class DBinit : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            context.user.Add(new User() { usrName = "1", mail = "1",ico = "1",ifAdmin = true,pswrd = "1"});
            base.Seed(context);
        }
    }
}