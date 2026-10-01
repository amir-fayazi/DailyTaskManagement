using DailyTaskManagement.DTOs;
using DailyTaskManagement.Entities;
using DailyTaskManagement.Enums;
using DailyTaskManagement.Infrastructure.Repositories;


namespace DailyTaskManagement.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        private readonly ITaskRepository _taskRepo;

        public DailyTaskService(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public void ChangePriority(int userId, int taskId, PriorityEnum priority)
        {
            if (!Enum.IsDefined(priority))
                throw new ArgumentOutOfRangeException(nameof(priority));

            int rowAffected = _taskRepo.UpdatePriority(userId, taskId, priority);

            if (rowAffected == 0)
                throw new Exception("Task Not Found");
        }

        public void ChangeStatus(int userId, int taskId, StatusEnum status)
        {
            if (!Enum.IsDefined(status))
                throw new ArgumentOutOfRangeException(nameof(status));

            int rowAffected = _taskRepo.UpdateStatus(userId, taskId, status);

            if (rowAffected == 0)
                throw new Exception("Task Not Found");
        }

        public void CreateTask(int userId, string title, StatusEnum status, PriorityEnum priority)
        {
            if (!Enum.IsDefined(status))
                throw new ArgumentOutOfRangeException(nameof(status));

            if (!Enum.IsDefined(priority))
                throw new ArgumentOutOfRangeException(nameof(priority));

            var task = new DailyTask(userId, title, status, priority);
            _taskRepo.Add(task);
        }

        public IReadOnlyCollection<TaskDto> GetTasksByUserId(int userId)
        {
            return _taskRepo.GetByUserId(userId);
        }
    }
}
