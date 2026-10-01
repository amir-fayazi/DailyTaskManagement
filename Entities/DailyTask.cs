

using DailyTaskManagement.Enums;

namespace DailyTaskManagement.Entities
{
    public class DailyTask : BaseEntity
    {
        public string Title { get; private set; } = null!;
        public StatusEnum Status { get; set; } 
        public PriorityEnum Priority { get; set; }

        public User User { get; set; } = null!;
        public int UserId { get; set; }


        public DailyTask(int userId, string title, StatusEnum status, PriorityEnum priority)
        {
            ValidateTitle(title);

            UserId = userId;
            Title = title;
            Status = status;
            Priority = priority;
        }

        private void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required.", nameof(title));

            if (title.Length > 100)
                throw new ArgumentException( "Title cannot be more than 100 characters.",nameof(title));

        }
    }
}
