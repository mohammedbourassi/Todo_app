using Todo_app.Enums;

namespace Todo_app.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public TodoState State { get; set; } // "ToDo", "Doing", "Done"
        public DateTime DateLimite { get; set; }
        public Guid UserId { get; set; }
        
    }
}
