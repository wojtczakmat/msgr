using System;
using msgr.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace msgr.Services
{
    public interface IUserService
    {
        Guid? Check(string username, string passwordHash);
        void Add(User user);
        User GetUserById(Guid userId);

        Task LogIn(Guid userId, Microsoft.AspNetCore.Http.HttpContext httpContext);
    }
}