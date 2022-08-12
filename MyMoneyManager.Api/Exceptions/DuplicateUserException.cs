namespace MyMoneyManager.Api.Exceptions;

public class DuplicateUserException : Exception
{
    public DuplicateUserException(String userName) : base($"User \"{userName}\" already exists") { }
}
