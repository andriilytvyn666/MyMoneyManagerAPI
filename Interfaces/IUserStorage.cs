namespace MyMoneyManagerApi.Interfaces;

using MyMoneyManagerApi.Models;

public interface IUserStorage
{
    public User Create(User user);
    public User Read(Int64 userId);
    public User Read(String userName);
    public User Update(User user);
    public User Delete(Int64 userId);

    public List<User> GetUsersList();
}
