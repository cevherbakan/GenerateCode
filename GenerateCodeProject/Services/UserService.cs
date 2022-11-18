using GenerateCodeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenerateCodeProject.Services
{
    public class UserService
    {
        private Context _context;
        public UserService(Context context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }

        public User Login(User user)
        {
            var result = _context.User
                .Where(x => x.UserName == user.UserName && x.Password == user.Password)
                .FirstOrDefault();

            return result;
        }
    }
}
