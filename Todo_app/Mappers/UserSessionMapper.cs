using Todo_app.Models;

namespace Todo_app.Mappers
{
    public class UserSessionMapper
    {
        public static UserSession GetUserSessionFromUser(User user)
        {
            return new UserSession()
            {
                Id = user.Id,
                Username = user.Username,
            };
        }
    }
}
