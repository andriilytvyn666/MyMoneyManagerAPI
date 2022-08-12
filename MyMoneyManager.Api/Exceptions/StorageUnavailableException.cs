namespace MyMoneyManager.Api.Exceptions;

public class StorageUnavailableException : StorageException
{
    public StorageUnavailableException() : base() { }
    public StorageUnavailableException(String message) : base(message) { }
    public StorageUnavailableException(String message, Exception e) : base(message, e) { }
}

public class StorageException : Exception
{
    public StorageException() : base() { }
    public StorageException(String message) : base(message) { }
    public StorageException(String message, Exception e) : base(message, e) { }
}
