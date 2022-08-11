using MyMoneyManagerApi.Models;

namespace MyMoneyManagerApi.Interfaces;

interface IUserService
{
    public User Create(User user);
    public User Read(User user);
    public User Read(Int64 userId);
    public User Read(String userName);
    public User Update(User user);
    public User Delete(User user);
}
