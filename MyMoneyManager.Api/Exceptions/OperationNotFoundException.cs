namespace MyMoneyManager.Api.Exceptions;

public class OperationNotFoundException : NotFoundException
{
    public OperationNotFoundException(Int64 operationId) : base($"Could not find operation with Id \"{operationId}\"") { }
}
