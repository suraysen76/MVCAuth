using MVCAuth.Models;
using Microsoft.AspNetCore.Authentication;
using MVCAuth.Interfaces;
using MVCAuth.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace MVCAuth.Services
{
    public class AuthService : IAuthService
    {
        private readonly MVCAuthDbContext _context;

        public AuthService(MVCAuthDbContext context)
        {
            _context = context;

        }
        public bool AuthenticateUser(LoginModel model)
        {
            var x = _context.Users;
            bool authenticated = false;
            var user = _context.Users.Where(u => u.UserName == model.UserName && u.Password == model.Password).FirstOrDefault();
            if (user != null)
            {
                   authenticated = true;
            }
            return  authenticated;
            
        }

        public bool RegisterUser(UserModel model)
        {
            bool registered = false;
            var user = _context.Users.Where(u => u.UserName == model.UserName && u.Password == model.Password).FirstOrDefault();
            if (user != null)//user with same UserId exist
            {
                registered = false;
            }
            else
            {
                var Loginodel = new LoginModel() { Name= model.Name, Password = model.Password, UserName=model.UserName };
                 _context.Users.Add(Loginodel);
                 _context.SaveChanges();

                registered = true;
            }
            return registered;
            ;
        }

        public UserModel GetProfile(string userName)
        {
            var user = _context.Users.Where(u => u.UserName == userName ).FirstOrDefault();
            if (user != null)
            {
                var userModel = new UserModel() { Name = user.Name, UserName = user.Name };
                return userModel;
            }
            return null;
            ;
        }
    }
}
