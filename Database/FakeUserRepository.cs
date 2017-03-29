using System;
using msgr.Models;

namespace msgr.Database
{
    public class FakeUserRepository : IRepository<User>
    {
        public void Add(User obj)
        {
        }

        public User Get(Guid id)
        {
            return User.Create("test", "test");
        }
    }
}