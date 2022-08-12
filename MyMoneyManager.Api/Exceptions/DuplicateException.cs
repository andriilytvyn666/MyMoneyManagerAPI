namespace MyMoneyManager.Api.Exceptions;

public class DuplicateException : Exception
{
    public DuplicateException() : base() { }
    public DuplicateException(String message) : base(message) { }
    public DuplicateException(String message, Exception e) : base(message, e) { }
}
