using Todo_app.Models;
using Todo_app.ViewModel;

namespace Todo_app.Mappers
{
    public class UserMapper
    {
        public static User GetUserFromSignupVM(SignupVM signupVM)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Username = signupVM.Username,
                Email = signupVM.Email,
                Password = signupVM.Password
            };
        }
    }
}
