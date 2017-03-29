using System;

namespace msgr.Services
{
    public interface IUserService
    {
        Guid? Check(string username, string passwordHash);
    }
}