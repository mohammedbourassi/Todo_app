using Todo_app.Models;
using Todo_app.Repositories;

namespace Todo_app.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool UserExists(string email)
        {
            return _userRepository.GetUser(email) != null;
        }
    }
}
