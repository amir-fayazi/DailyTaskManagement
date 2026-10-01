

using DailyTaskManagement.Entities;

namespace DailyTaskManagement.Services
{
    public interface IAuthenticationService
    {
        User Login(string username, string password);
    }
}
