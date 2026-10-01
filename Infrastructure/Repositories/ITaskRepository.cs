
using DailyTaskManagement.DTOs;
using DailyTaskManagement.Entities;
using DailyTaskManagement.Enums;

namespace DailyTaskManagement.Infrastructure.Repositories
{
    public interface ITaskRepository
    {

        IReadOnlyCollection<TaskDto> GetByUserId(int userId);
        bool Add(DailyTask task);
        int UpdateStatus(int userId, int taskId, StatusEnum status);
        int UpdatePriority(int userId, int taskId, PriorityEnum priority);
    }
}
