namespace Todo_app.Services
{
    public interface IUserService
    {
        bool UserExists(string email);
    }
}
