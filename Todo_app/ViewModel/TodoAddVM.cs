using System.ComponentModel.DataAnnotations;
using Todo_app.Enums;

namespace Todo_app.ViewModel
{
    public class TodoAddVM
    {
        [Required(ErrorMessage = "Le libelle est obligatoire")]
        public string Libelle { get; set; }
        [Required(ErrorMessage = "La description est obligatoire")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Le statut est obligatoire")]
        public TodoState State { get; set; } // "ToDo", "Doing", "Done"
        [Required(ErrorMessage = "La date limite est obligatoire")]
        public DateTime DateLimite { get; set; }
    }
}
