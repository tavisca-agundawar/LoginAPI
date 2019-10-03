
namespace AuthenticationAPI.Model
{
    public class User
    {
        public string Username { get; private set; }
        internal string Password { get; private set; }

        public string UserType { get; private set; }

        public User(string username, string password, string userType)
        {
            Username = username;
            Password = password;
            UserType = userType;
        }
    }
}
