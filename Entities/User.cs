namespace DailyTaskManagement.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; private set; } = null!;
        public string Password { get; private set; } = null!;

        public ICollection<DailyTask> Tasks { get; set; } = [];

        public User(string username, string password)
        {
            ValidateUsername(username);

            Password = password;
            Username = username;
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required.", nameof(username));

            if (username.Length > 50)
                throw new ArgumentException("Username cannot be more than 50 characters.", nameof(username));

        }
    }
}
