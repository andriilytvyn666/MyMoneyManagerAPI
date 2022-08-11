using MyMoneyManagerApi.Interfaces;
using MyMoneyManagerApi.Models;
using MyMoneyManagerApi.Storage;

namespace MyMoneyManagerApi.Services;

public class OperationService : IOperationService
{
    private IOperationStorage _storage;
    private static readonly Lazy<OperationService> _lazy = new(() => new());
    public static OperationService Instance { get { return _lazy.Value; } }

    private OperationService()
    {
        _storage = SqliteOperationStorage.Instance;
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
