namespace Todo_app.Repositories
{
    using System.Text.Json;
    using Todo_app.Models;

    public class TodoRepository : ITodoRepository
    {
        private readonly IWebHostEnvironment _env;

        public TodoRepository(IWebHostEnvironment env)
        {
            _env = env;
        }

        private string GetUserFilePath(Guid userId)
        {
            // Tous les JSON des utilisateurs dans "wwwroot/data/todos"
            var folder = Path.Combine(_env.WebRootPath, "data", "todos");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return Path.Combine(folder, $"{userId}.json");
        }

        public List<Todo> GetAll(Guid userId)
        {
            var path = GetUserFilePath(userId);
            if (!File.Exists(path)) return new List<Todo>();

            var json = File.ReadAllText(path);
            return string.IsNullOrWhiteSpace(json) ? new List<Todo>() : JsonSerializer.Deserialize<List<Todo>>(json);
        }

        public void SaveAll(Guid userId, List<Todo> todos)
        {
            var path = GetUserFilePath(userId);
            var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }

}
