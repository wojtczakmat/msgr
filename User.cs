using System;

namespace msgr
{
    public class User
    {
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        private string userID;
        public string UserID
        {
            get
            {
                return userID;
            }
        }
        private bool isActive;
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
            }
        }
        private DateTime lastSeen;
        public DateTime LastSeen
        {
            get
            {
                return lastSeen;
            }
            set
            {
                lastSeen = value;
            }
        }
        private User(string userID, string userName)
        {
            this.userID = userID;
            this.userName  = userName;
            this.isActive = false;
            this.lastSeen = DateTime.MinValue;
        }
    }
}