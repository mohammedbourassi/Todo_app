using Todo_app.Mappers;
using Todo_app.Models;
using Todo_app.Repositories;
using Todo_app.ViewModel;

namespace Todo_app.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public List<Todo> GetAll(Guid userId) => _repository.GetAll(userId);

        public void Add(Guid userId, TodoAddVM vm)
        {
            
            var todos = _repository.GetAll(userId);
            Todo todo = TodoMapper.GetTodoFromTodoAddVM(vm, userId);
            todos.Add(todo);
            _repository.SaveAll(userId, todos);
        }

        public void Update(Guid userId, Todo todo)
        {
            var todos = _repository.GetAll(userId);
            var existing = todos.FirstOrDefault(t => t.Id == todo.Id);
            if (existing != null)
            {
                existing.Libelle = todo.Libelle;
                existing.Description = todo.Description;
                existing.State = todo.State;
                existing.DateLimite = todo.DateLimite;
                _repository.SaveAll(userId, todos);
            }
        }

        public void Delete(Guid userId, Guid todoId)
        {
            var todos = _repository.GetAll(userId);
            todos = todos.Where(t => t.Id != todoId).ToList();
            _repository.SaveAll(userId, todos);
        }
    }

}
