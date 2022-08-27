using System;
using System.Data;

namespace CountyProject
{
    public class User : IEquatable<User>
    {
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Remember = false;
        }

        public string UserName
        {
            get;
        }

        public string Password
        {
            get;
            set;
        }

        public bool Remember
        {
            get;
            set;
        }

        public bool Equals(User user)
        {
            return UserName == user.UserName && Password == user.Password && Remember == user.Remember;
        }

        public static User GetUser(DataRow entry)
        {
            return new User((string)entry["UserName"], (string)entry["Password"]);
        }
    }
}