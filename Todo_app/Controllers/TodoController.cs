using Microsoft.AspNetCore.Mvc;
using Todo_app.Filters;
using Todo_app.Mappers;
using Todo_app.Models;
using Todo_app.Services;
using Todo_app.ViewModel;

namespace Todo_app.Controllers
{
    [AuthFilter]
    public class TodoController : Controller
    {
        private readonly ITodoService _service;
        private readonly ISessionManagerService _session;

        public TodoController(ITodoService service, ISessionManagerService session)
        {
            _service = service;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TodoAddVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            UserSession user = _session.GetSession("user", HttpContext);
            _service.Add(user.Id, vm);
            return View(vm);
        }

        public IActionResult List()
        {
            var user = _session.GetSession("user", HttpContext);
            var todos = _service.GetAll(user.Id);
            return View("List", todos); 
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var user = _session.GetSession("user", HttpContext);
            if (user == null)
                return RedirectToAction("Login", "Auth");

            _service.Delete(user.Id, id);
            return RedirectToAction("List");
        }

    }
}
