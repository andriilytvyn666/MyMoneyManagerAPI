using MyMoneyManagerApi.Interfaces;
using MyMoneyManagerApi.Models;

namespace MyMoneyManagerApi.Storage;

// TODO: Make all methods async
public class SqliteUserStorage : IUserStorage
{
    private SqliteDbContext _db;
    private static readonly Lazy<SqliteUserStorage> _lazy = new(() => new());
    public static SqliteUserStorage Instance { get { return _lazy.Value; } }

    private SqliteUserStorage()
    {
        _db = new();
    }

    public User Create(User user)
    {
        User createdUser;

        // TODO: Throw exception when user with same is already exists
        createdUser = _db.Add(user).Entity;
        _db.SaveChanges();

        return createdUser;
    }

    public User Read(Int64 userId)
    {

        User user;

        user = _db.Users.Single(x => x.UserId == userId);

        return user;
    }


    public User Read(String userName)
    {

        User user;

        // TODO: Throw exception when user not found
        user = _db.Users.Single(x => x.UserName == userName);

        return user;
    }

    public User Update(User user)
    {
        User updatedUser;

        updatedUser = _db.Users.First(x => x.UserId == user.UserId);

        // TODO: Throw exception when UserId is changed
        updatedUser.UserName = user.UserName;
        updatedUser.FullName = user.FullName;
        updatedUser.FullName = user.Email;
        updatedUser.Password = user.Password;
        updatedUser.Privileges = user.Privileges;

        _db.SaveChanges();

        return updatedUser;
    }

    public User Delete(Int64 userId)
    {
        // TODO: Throw exception when user not found
        User userToDelete = _db.Users.First(x => x.UserId == userId);

        User deletedUser = _db.Remove(userToDelete).Entity;
        _db.SaveChanges();

        return deletedUser;
    }

    public List<User> GetUsersList()
    {
        return _db.Users.ToList();
    }
}
