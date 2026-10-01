
using DailyTaskManagement.DTOs;
using DailyTaskManagement.Enums;

namespace DailyTaskManagement.Services
{
    public interface IDailyTaskService
    {
        IReadOnlyCollection<TaskDto> GetTasksByUserId(int userId);

        void CreateTask(int userId, string title, StatusEnum status, PriorityEnum priority);

        void ChangeStatus(int userId, int taskId, StatusEnum status);
        void ChangePriority(int userId, int taskId, PriorityEnum priority);
    }
}
