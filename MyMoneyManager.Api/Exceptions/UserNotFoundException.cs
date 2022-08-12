namespace MyMoneyManager.Api.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(String userName) : base($"Could not find user \"{userName}\"") { }
}
