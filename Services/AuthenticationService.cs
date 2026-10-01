using DailyTaskManagement.Entities;
using DailyTaskManagement.Infrastructure.Repositories;


namespace DailyTaskManagement.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserRepository _userRepo;

        public AuthenticationService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public User Login(string username, string password)
        {
            var user = _userRepo.GetByUsername(username);

            if (username is null || user.Password != password)
                throw new Exception("Username or password is incorrect.");

            return user;
        }
    }
}
