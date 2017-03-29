using System;
using msgr.Database;
using msgr.Models;
using System.Linq;

namespace msgr.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Guid? Check(string username, string passwordHash)
        {
            User user = dbContext.Users.Where(x => x.UserName == username).SingleOrDefault();
            if (user == null)
                return null;
            return user.PasswordHash == passwordHash ? (Guid?)user.Id : null;
        }
    }
}