namespace MyMoneyManager.Api.Exceptions;

public class ServiceUnavailableException : Exception
{
    public ServiceUnavailableException() : base() { }
    public ServiceUnavailableException(String message) : base(message) { }
    public ServiceUnavailableException(String message, Exception e) : base(message, e) { }
}
