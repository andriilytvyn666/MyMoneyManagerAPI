namespace MyMoneyManager.Api.Exceptions;

public class DuplicateOperationException : DuplicateException
{
    public DuplicateOperationException(Int64 operationId) : base($"Operation with Id \"{operationId}\" already exists") { }
}
