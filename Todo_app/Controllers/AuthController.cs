using Microsoft.AspNetCore.Mvc;
using Todo_app.Services;
using Todo_app.ViewModel;

namespace Todo_app.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ISessionManagerService _sessionManagerService;

        public AuthController(IAuthService authService, IUserService userService, ISessionManagerService sessionManagerService)
        {
            _authService = authService;
            _userService = userService;
            _sessionManagerService = sessionManagerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupVM signup)
        {
            if (!ModelState.IsValid)
            {
                return View(signup);
            }
            if(_userService.UserExists(signup.Email))
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(signup);
            }

            _authService.RegisterUser(signup);
            _sessionManagerService.AddSession("user", signup, HttpContext);

            return RedirectToAction("Add", "Todo");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            if (_authService.LoginUser(login) == false)
            {
                ModelState.AddModelError("","Invalid username or password");
                return View(login);
            }
            _sessionManagerService.AddSession("user", login, HttpContext);
            return RedirectToAction("Add", "Todo");
        }

    }
}
