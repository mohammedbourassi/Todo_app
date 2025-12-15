using Todo_app.Models;

namespace Todo_app.Services
{
    public interface ISessionManagerService
    {
        void AddSession(string key, object obj, HttpContext httpContext);
        void RemoveSession(string key, HttpContext httpContext);
        UserSession? GetSession(string key, HttpContext httpContext);
    }
}
