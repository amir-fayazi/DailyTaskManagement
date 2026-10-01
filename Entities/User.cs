namespace DailyTaskManagement.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; private set; } = null!;
        public string Password { get; private set; } = null!;

        public ICollection<Tasks> Tasks { get; set; } = [];

        public User(string username, string password)
        {
            ValidateUsername(username);

            Password = password;
            Username = username;
        }

        private void ValidateUsername(string username)
        {
            if (username.Length > 50)
                throw new Exception("");

            if(string.IsNullOrWhiteSpace(username))
                throw new Exception("");

        }
    }
}
