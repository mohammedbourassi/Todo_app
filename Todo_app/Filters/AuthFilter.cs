using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Todo_app.Services;

namespace Todo_app.Filters
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessionService = context.HttpContext
                .RequestServices
                .GetService<ISessionManagerService>();

            var user = sessionService?.GetSession("user", context.HttpContext);

            if (user == null)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }
    }
}
