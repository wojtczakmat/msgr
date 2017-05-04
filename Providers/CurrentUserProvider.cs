using System;
using Microsoft.AspNetCore.Http;

namespace msgr.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        IHttpContextAccessor httpContextAccessor;
        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public Guid? GetCurrentUserId()
        {     
            var user = httpContextAccessor.HttpContext.User;
            
            
            if (user.FindFirst("sub") == null)
                return null;
            return Guid.Parse(user.FindFirst("sub").Value);
        }
    }
}