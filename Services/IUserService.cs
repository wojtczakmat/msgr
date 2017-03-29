namespace msgr.Services
{
    public interface IUserService
    {
        bool Check(string username, string passwordHash);
    }
}