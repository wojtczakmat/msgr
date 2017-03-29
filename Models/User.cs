using System;
using msgr.Models.Interfaces;

namespace msgr.Models
{
    public class User : IAggregateRoot<Guid>
    {
        protected User() {}
        public static User Create(string username, string passwordHash)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                UserName = username,
                PasswordHash = passwordHash
            };
        } 
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastSeen { get; set; }
    }
}