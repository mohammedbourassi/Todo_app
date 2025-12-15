using Todo_app.Models;

namespace Todo_app.Repositories
{
    public interface ITodoRepository
    {
        
        List<Todo> GetAll(Guid userId);
        void SaveAll(Guid userId, List<Todo> todos);
    }
}
