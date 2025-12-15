using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Text.Json;
using Todo_app.Mappers;
using Todo_app.Models;
using Todo_app.Repositories;
using Todo_app.ViewModel;

namespace Todo_app.Services
{
    public class SessionManagerService : ISessionManagerService
    {
        private readonly IUserRepository _userRepository;
        public SessionManagerService(IUserRepository userRepository) {
            _userRepository = userRepository;      
        }
        public void AddSession(string key, object obj, HttpContext httpContext)
        {
            if(obj is LoginVM login)
            {
                User user =  _userRepository.GetUser(login.Email);
                UserSession userSession = UserSessionMapper.GetUserSessionFromUser(user);
                string chain = JsonSerializer.Serialize(userSession);
                httpContext.Session.SetString(key, chain);
            }
            else if(obj is SignupVM signup)
            {
                User user = _userRepository.GetUser(signup.Email);
                UserSession userSession = UserSessionMapper.GetUserSessionFromUser(user);
                string chain = JsonSerializer.Serialize(userSession);
                httpContext.Session.SetString(key, chain);
            }
            

        }
        public UserSession? GetSession(string key, HttpContext httpContext)
        {
            var json = httpContext.Session.GetString(key);

            if (string.IsNullOrEmpty(json))
                return null;

            return JsonSerializer.Deserialize<UserSession>(json);
        }

        public void RemoveSession(string key, HttpContext httpContext)
        {
            httpContext.Session.Remove(key);
        }
    }
}
