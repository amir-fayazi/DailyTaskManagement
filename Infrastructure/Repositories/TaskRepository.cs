using DailyTaskManagement.DTOs;
using DailyTaskManagement.Entities;
using DailyTaskManagement.Enums;
using DailyTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(DailyTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return true;
        }

        public IReadOnlyCollection<TaskDto> GetByUserId(int userId)
        {
            return [.._context.Tasks
                    .Where(t => t.UserId == userId)
                    .Select(t => new TaskDto{
                        Id =t.Id,
                        Title = t.Title,
                        Status = t.Status,
                        Priority = t.Priority,
                        CreatedAt = t.CreatedAt
                    })];
        }

        public int UpdatePriority(int userId, int taskId, PriorityEnum priority)
        {
            int affectedRow = _context.Tasks
                .Where(t => t.Id == taskId && t.UserId == userId)
                .ExecuteUpdate(setters => setters
                .SetProperty(c => c.Priority, priority));

            if (affectedRow == 0)
                throw new Exception("Task not found.");

            return affectedRow;
        }

        public int UpdateStatus(int userId, int taskId, StatusEnum status)
        {
            int affectedRow = _context.Tasks
                .Where(t => t.Id == taskId && t.UserId == userId)
                .AsNoTracking()
                .ExecuteUpdate(setters => setters
                .SetProperty(t => t.Status, status));

            if (affectedRow == 0)
                throw new Exception("Task not found.");

            return affectedRow;
        }
    }
}
