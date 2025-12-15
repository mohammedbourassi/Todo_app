using Todo_app.ViewModel;

namespace Todo_app.Services
{
    public interface IAuthService
    {
        void RegisterUser(SignupVM signup);
        bool LoginUser(LoginVM login);
    }
}
