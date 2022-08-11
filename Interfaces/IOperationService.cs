using MyMoneyManagerApi.Models;

namespace MyMoneyManagerApi.Interfaces;

interface IOperationService
{
    public Operation Create(Operation operation);
    public Operation Read(Operation operation);
    public Operation Read(Int64 operationId);
    public Operation Update(Operation operation);
    public Operation Delete(Operation operation);

    public List<Operation> GetOperationsList(Int64 notebookId);
    public List<Operation> GetOperationsList(Notebook notebook);
}
