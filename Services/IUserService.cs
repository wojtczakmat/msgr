using System;
using msgr.Models;

namespace msgr.Services
{
    public interface IUserService
    {
        Guid? Check(string username, string passwordHash);
        void Add(User user);
        User GetUserById(Guid userId);
    }
}