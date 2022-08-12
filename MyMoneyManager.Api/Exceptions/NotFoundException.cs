namespace MyMoneyManager.Api.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base() { }
    public NotFoundException(String message) : base(message) { }
    public NotFoundException(String message, Exception e) : base(message, e) { }
}
