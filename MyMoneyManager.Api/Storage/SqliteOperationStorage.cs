using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;

namespace MyMoneyManager.Api.Storage;

// TODO: Make all methods async
public class SqliteOperationStorage : IOperationStorage
{
    private IServiceScopeFactory _scopeFactory;

    public SqliteOperationStorage(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Operation Create(Operation operation)
    {
        Operation createdOperation;

        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            // TODO: Throw exception when operation with same OperationId already exists
            createdOperation = _db.Add(operation).Entity;
            _db.SaveChanges();
        }

        return createdOperation;
    }

    public Operation Read(Int64 operationId)
    {

        Operation operation;
        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {

            operation = _db.Operations.Single(x => x.OperationId == operationId);
        }

        return operation;
    }

    public Operation Update(Operation operation)
    {
        Operation updatedOperation;
        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {

            updatedOperation = _db.Operations.First(x => x.OperationId == operation.OperationId);

            // TODO: Throw exception when OperationId is changed
            updatedOperation.Name = operation.Name;
            updatedOperation.Amount = operation.Amount;
            updatedOperation.Type = operation.Type;
            updatedOperation.Category = operation.Category;

            _db.SaveChanges();
        }

        return updatedOperation;
    }

    public Operation Delete(Int64 operationId)
    {
        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            // TODO: Throw exception when Operation is not found
            Operation operationToDelete = _db.Operations.First(x => x.OperationId == operationId);
            Operation deletedOperation = _db.Remove(operationToDelete).Entity;
            _db.SaveChanges();

            return deletedOperation;
        }
    }

    public List<Operation> GetOperationsList(Int64 notebookId)
    {
        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            return _db.Operations.Where(x => x.NotebookId == notebookId).ToList();
        }
    }
}
