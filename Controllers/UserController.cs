using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chitalka.Models;

namespace Chitalka.Controllers
{
    public class UserController : Controller
    {
        DBContext DBCont = new DBContext();
        [HttpGet]
        public ActionResult Page(int id)
        {
            var user1 = from user in DBCont.user.AsEnumerable()
                        where user.id == id
                        select user;
            ViewBag.user1 = user1;
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            DBCont.user.Add(user);
            DBCont.SaveChanges();
            var message = 1;
            ViewBag.message = message;
            return View();
        }
        public ActionResult AuthUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthUser(User userInp)
        {
            var userName = from user in DBCont.user.AsEnumerable()
                        where user.usrName == userInp.usrName
                        select user;
            var userPass = from user in DBCont.user.AsEnumerable()
                           where user.pswrd == userInp.pswrd
                           select user;
            var message = 1;
            if(userName != null)
            {
                if (userPass != null)
                {
                    message = 1;
                }
                else
                {
                    message = 2;//pswrd err
                }
            }
            else
            {
                message = 3;//username errrrrrrrrrrror
            }
            ViewBag.message = message;
            return View();
        }
    }
}