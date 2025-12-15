using System.Security.Cryptography;
using System.Text;
using Todo_app.Mappers;
using Todo_app.Models;
using Todo_app.Repositories;
using Todo_app.ViewModel;

namespace Todo_app.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public void RegisterUser(SignupVM signup) {
            User user = UserMapper.GetUserFromSignupVM(signup);
            user.Password = HashPassword(signup.Password);
            _userRepository.AddUser(user);
        }

        public bool LoginUser(LoginVM login)
        {
            List<User> users = _userRepository.GetUsers();
            if (users.Exists(u => u.Email == login.Email && u.Password == HashPassword(login.Password)))
            {
                return true;
            }
            return false; 
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

    }
}
