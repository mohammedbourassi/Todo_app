using Todo_app.Models;
using Todo_app.ViewModel;

namespace Todo_app.Mappers
{
    public class TodoMapper
    {
        public static Todo GetTodoFromTodoAddVM(TodoAddVM todoAddVM , Guid UserId)
        {
            return new Todo()
            {
                Id = Guid.NewGuid(),
                Libelle = todoAddVM.Libelle,
                Description = todoAddVM.Description,
                State = todoAddVM.State,
                DateLimite = todoAddVM.DateLimite,
                UserId = UserId
            };
        }
    }
}
