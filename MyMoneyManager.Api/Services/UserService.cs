using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;

namespace MyMoneyManager.Api.Services;

public class UserService : IUserService
{
    private IUserStorage _userStorage;

    public UserService(IUserStorage userStorage)
    {
        _userStorage = userStorage;
    }

    public User Create(User user)
    {
        return _userStorage.Create(user);
    }

    public User Read(User user)
    {
        return Read(user.UserId);
    }

    public User Read(String userName)
    {
        return _userStorage.Read(userName);
    }

    public User Read(Int64 userId)
    {
        return _userStorage.Read(userId);
    }

    public User Update(User user)
    {
        return _userStorage.Update(user);
    }

    public User Delete(User user)
    {
        return _userStorage.Delete(user.UserId);
    }

    public List<User> GetUsersList()
    {
        return _userStorage.GetUsersList();
    }
}
