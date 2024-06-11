using MVCAuth.Models;

namespace MVCAuth.Interfaces
{
    public interface IAuthService
    {
        bool AuthenticateUser(LoginModel model);
        bool RegisterUser(UserModel model);
        public UserModel GetProfile(string userName);
    }
}
