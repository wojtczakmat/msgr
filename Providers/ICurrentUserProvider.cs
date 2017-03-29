using System;

namespace msgr.Providers
{
    public interface ICurrentUserProvider
    {
        Guid? GetCurrentUserId();
    }
}