using System;
using System.Collections.Generic;
using System.Linq;
using msgr.Models;

namespace msgr.Database
{
    public class UserRepository : IRepository<User>
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

        public IList<User> GetAll()
        {
            return dbContext.Users.ToList();
        }
        public void Add(User user)
        {
            dbContext.Add(user);
            dbContext.SaveChanges();
        }
    }
}