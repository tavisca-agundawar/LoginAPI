#define DEBUG
using AuthenticationAPI.Model;
using System.Collections.Generic;

namespace AuthenticationAPI.Database
{
    public class UserDatabase
    {
        private static readonly List<User> _users = new List<User>();
#if DEBUG
        public UserDatabase()
        {
            _users.Add(new User("arnaw", "arnaw123", "Trainee"));
            _users.Add(new User("admin", "admin123", "Trainer"));
        }
#endif

        //Assuming username is primary key
        public User GetUserByUsername(string username)
        {
            User requestedUser = _users.Find(user => user.Username == username);
            if (requestedUser != null)
            {
                return requestedUser;
            }
            else
            {
                return null;
            }
        }

    }
}
