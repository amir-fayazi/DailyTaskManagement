using DailyTaskManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskManagement.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
    }
}
