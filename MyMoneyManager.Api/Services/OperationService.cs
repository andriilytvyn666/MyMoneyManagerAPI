using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;

namespace MyMoneyManager.Api.Services;

public class OperationService : IOperationService
{
    private IOperationStorage _storage;

    public OperationService(IOperationStorage operationService)
    {
        _storage = operationService;
    }

    public Operation Create(Operation operation)
    {
        return _storage.Create(operation);
    }

    public Operation Read(Operation operation)
    {
        return Read(operation.OperationId);
    }

    public Operation Read(Int64 operationId)
    {
        return _storage.Read(operationId);
    }

    public Operation Update(Operation operation)
    {
        return _storage.Update(operation);
    }

    public Operation Delete(Operation operation)
    {
        return _storage.Delete(operation.OperationId);
    }

    public List<Operation> GetOperationsList(Notebook notebook)
    {
        return GetOperationsList(notebook.NotebookId);
    }

    public List<Operation> GetOperationsList(Int64 notebookId)
    {
        return _storage.GetOperationsList(notebookId);
    }
}
