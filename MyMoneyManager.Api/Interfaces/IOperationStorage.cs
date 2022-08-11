using MyMoneyManagerApi.Models;

namespace MyMoneyManagerApi.Interfaces;

public interface IOperationStorage
{
    public Operation Create(Operation operation);
    public Operation Read(Int64 operationId);
    public Operation Update(Operation operation);
    public Operation Delete(Int64 operationId);

    public List<Operation> GetOperationsList(Int64 notebookId);
}
