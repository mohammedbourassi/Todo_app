using Todo_app.Models;

namespace Todo_app.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string email);
        List<User> GetUsers();
        void AddUser(User user);
    }
}
