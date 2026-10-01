

using DailyTaskManagement.Enums;

namespace DailyTaskManagement.Entities
{
    public class Tasks : BaseEntity
    {
        public string Title { get; private set; } = null!;
        public StatusEnum Status { get; set; } 
        public PriorityEnum Priority { get; set; }

        public User User { get; set; } = null!;
        public int UserId { get; set; }


        public Tasks(string title)
        {
            ValidateTitle(title);

            Title = title;
        }

        private void ValidateTitle(string title)
        {
            if (title.Length > 100)
                throw new Exception("");

            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("");

        }
    }
}
