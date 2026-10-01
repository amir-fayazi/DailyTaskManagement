using DailyTaskManagement.Enums;

namespace DailyTaskManagement.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public StatusEnum Status { get; set; }
        public PriorityEnum Priority { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
