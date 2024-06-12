using MVCAuth.Models;
using MVCAuth.Interfaces;
using MVCAuth.Handler;

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
            var user = _context.Users.Where(u => u.UserName == model.UserName).FirstOrDefault();
            bool authenticated = false;
            var pwdModel= PasswordHandler.GetPasswordModel(model.Password,user.Password);
            
            if (user != null && pwdModel.Verified)
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
                var Loginodel = new LoginModel() {  };
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
