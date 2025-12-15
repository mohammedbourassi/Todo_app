using Todo_app.Models;
using Todo_app.ViewModel;

namespace Todo_app.Services
{
    public interface ITodoService
    {
        void Add(Guid userId, TodoAddVM vm);
        List<Todo> GetAll(Guid userId);

        void Update(Guid userId, Todo todo);

        void Delete(Guid userId, Guid todoId);
    }
}
