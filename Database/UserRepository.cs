using System;
using msgr.Models;

namespace msgr.Database
{
    public class UserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User Get(Guid id)
        {
            return dbContext.Users.Find(id);
        }
    }
}