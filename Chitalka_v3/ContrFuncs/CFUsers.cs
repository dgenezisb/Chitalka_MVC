using Microsoft.EntityFrameworkCore;
using Chitalka_v3.Data;
using Chitalka_v3.Models;

namespace Chitalka_v3.ContrFuncs
{
    public class CFUsers
    {
        private readonly Chitalka_v3Context _context;
        public CFUsers(Chitalka_v3Context context)
        {
            _context = context;
        }

        public bool Auth(User user)
        {
            var i = 0;
            foreach(var a in _context.User)
            {
                if(a.mail == user.mail)
                {
                    i++;
                } 
            }
            foreach (var a in _context.User)
            {
                if (a.pswrd == user.pswrd)
                {
                    i++;
                }
            }
            foreach (var a in _context.User)
            {
                if (a.usrName == user.usrName)
                {
                    i++;
                }
            }
            if(i == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int id(User user)
        {
            int id = 0;
            foreach (var a in _context.User)
            {
                if (a.mail == user.mail)
                {
                    id = a.id;
                }
            }
            return id;
        }

        public User AddNotesToModel(User user)
        {
            user.UsrNotes = _context.UsrNotes.ToList();
            return user;
        }

        public User AddNotesToDB(User user,string Note)
        {
            var i = new UsrNotes();
            i.Note = Note;
            i.User = user.id;
            user.UsrNotes = new List<UsrNotes> {i};
            _context.UsrNotes.Add(i);
            return user;
        }
    }
}
