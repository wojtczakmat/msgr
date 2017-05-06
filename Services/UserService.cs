using System;
using System.Collections.Generic;
using System.Security.Claims;
using msgr.Database;
using msgr.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using msgr.Helpers;
//using msgr.Providers;
//using msgr.Services;
//using msgr.ViewModels;

namespace msgr.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User user)
        {
            dbContext.Add(user);
            dbContext.SaveChanges();
        }

        public Guid? Check(string username, string passwordHash)
        {
            User user = dbContext.Users.Where(x => x.UserName == username).SingleOrDefault();
            if (user == null)
                return null;
            return user.PasswordHash == passwordHash ? (Guid?)user.Id : null;
        }

        public User GetUserById(Guid userId)
        {
            return dbContext.Users.Where(x => x.Id == userId).SingleOrDefault();
        }

        public async Task LogIn(Guid userId, Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var claims = new List<Claim>() {
                    new Claim("sub", userId.ToString())
                };

            var id = new ClaimsIdentity(claims);
            var p = new ClaimsPrincipal(id);

            await httpContext.Authentication.SignInAsync("Cookies", p);
        }
    }
}