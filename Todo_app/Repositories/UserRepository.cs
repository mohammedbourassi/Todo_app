using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Text.Json;
using Todo_app.Models;

namespace Todo_app.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string _path;

        public UserRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.WebRootPath,"data", "users.json");
        }

        public List<User> GetUsers()
        {
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException("Create this wwwroot/data/users.json before starting the application");
            }

            var json = File.ReadAllText(_path);
            if (string.IsNullOrEmpty(json))
            {
                return new List<User>();
            }
            var users = JsonSerializer.Deserialize<List<User>>(json);
            return users;
        }

        public User GetUser(string email)
        {
            return GetUsers().FirstOrDefault(u => u.Email == email);
            
        }

        public void AddUser(User user)
        {   
            var users = GetUsers();
            users.Add(user);
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true })
            ;
            File.WriteAllText(_path, json);
        }
    }
}
