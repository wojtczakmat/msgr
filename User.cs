using System;

namespace msgr
{
    public class User
    {
        public string userName;
        public string userID;
        public bool isActive;
        public DateTime lastSeen;

        public User(string userID, string userName)
        {
            this.userID = userID;
            this.userName  = userName;
            this.isActive = false;
            this.lastSeen = DateTime.MinValue;
        }
    }
}