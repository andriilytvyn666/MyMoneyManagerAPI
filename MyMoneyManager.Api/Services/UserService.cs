using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;
using MyMoneyManager.Api.Storage;

namespace MyMoneyManager.Api.Services;

public class UserService : IUserService
{
    private IUserStorage _storage;
    private static readonly Lazy<UserService> _lazy = new(() => new());
    public static UserService Instance { get { return _lazy.Value; } }

    private UserService()
    {
        _storage = SqliteUserStorage.Instance;
    }

    public User Create(User user)
    {
        return _storage.Create(user);
    }

    public User Read(User user)
    {
        return Read(user.UserId);
    }

    public User Read(String userName)
    {
        return _storage.Read(userName);
    }

    public User Read(Int64 userId)
    {
        return _storage.Read(userId);
    }

    public User Update(User user)
    {
        return _storage.Update(user);
    }

    public User Delete(User user)
    {
        return _storage.Delete(user.UserId);
    }

    public List<User> GetUsersList()
    {
        return _storage.GetUsersList();
    }
}
