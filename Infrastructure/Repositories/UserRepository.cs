using DailyTaskManagement.Entities;
using DailyTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public User? GetByUsername(string username)
        {
            var user = _context.Users
                        .AsNoTracking()
                        .SingleOrDefault(u => u.Username == username);
          
            return user;
        }
    }
}
