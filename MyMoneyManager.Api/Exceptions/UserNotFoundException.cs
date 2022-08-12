namespace MyMoneyManager.Api.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(String userName) : base($"Could not find user \"{userName}\"") { }
}
