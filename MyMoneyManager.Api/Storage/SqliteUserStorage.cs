using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;

namespace MyMoneyManager.Api.Storage;

// TODO: Make all methods async
public class SqliteUserStorage : IUserStorage
{
    // private ApplicationDbContext _db;
    private IServiceScopeFactory _scopeFactory;

    // public SqliteUserStorage(ApplicationDbContext db)
    public SqliteUserStorage(IServiceScopeFactory scopeFactory)
    {
        // _db = db;
        _scopeFactory = scopeFactory;
    }

    public User Create(User user)
    {
        User createdUser;

        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            // TODO: Throw exception when user with same is already exists
            createdUser = _db.Add(user).Entity;
            _db.SaveChanges();
        }

        return createdUser;
    }

    public User Read(Int64 userId)
    {

        User user;

        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            user = _db.Users.Single(x => x.UserId == userId);
        }
        return user;
    }


    public User Read(String userName)
    {

        User user;

        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            // TODO: Throw exception when user not found
            user = _db.Users.Single(x => x.UserName == userName);
        }
        return user;
    }

    public User Update(User user)
    {
        User updatedUser;

        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            updatedUser = _db.Users.First(x => x.UserId == user.UserId);

            // TODO: Throw exception when UserId is changed
            updatedUser.UserName = user.UserName;
            updatedUser.FullName = user.FullName;
            updatedUser.FullName = user.Email;
            updatedUser.Password = user.Password;
            updatedUser.Privileges = user.Privileges;

            _db.SaveChanges();
        }
        return updatedUser;
    }

    public User Delete(Int64 userId)
    {
        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            // TODO: Throw exception when user not found
            User userToDelete = _db.Users.First(x => x.UserId == userId);

            User deletedUser = _db.Remove(userToDelete).Entity;
            _db.SaveChanges();

            return deletedUser;
        }
    }

    public List<User> GetUsersList()
    {
        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            return _db.Users.ToList();
        }
    }
}
