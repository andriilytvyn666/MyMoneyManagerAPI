namespace MyMoneyManager.Api.Exceptions;

public class DuplicateUserException : DuplicateException
{
    public DuplicateUserException(String userName) : base($"User \"{userName}\" already exists") { }
}
