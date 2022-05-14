namespace ChitalkaMVC.Logic.Users
{
    public class UserManager : IUserManager
    {
        private readonly ChitalkaContext _context;

        public UserManager(ChitalkaContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(User Nuser)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == Nuser.Username);
            if (user == null)
            {
                _context.Users.Add(Nuser);

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<(bool, bool)> Find(User Nuser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == Nuser.Username);
            if (user == null)
                return (false, false);
            var authRes = (auth:false, admin:false);
            if (user.Password != Nuser.Password)
                return (false, false);
            authRes.auth = true;
            if(user.isAdmin)
                authRes.admin = true;
            return authRes;
        }

        public async Task Delete(string username)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<User>> GetAll() => await _context.Users.ToListAsync();
    }
}
