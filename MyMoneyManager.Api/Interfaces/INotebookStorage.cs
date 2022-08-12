using MyMoneyManager.Api.Models;

namespace MyMoneyManager.Api.Interfaces;

public interface INotebookStorage
{
    public Notebook Create(Notebook notebook);
    public Notebook Read(Int64 notebookId);
    public Notebook Update(Notebook notebook);
    public Notebook Delete(Int64 notebook);

    public List<Notebook> GetNotebooksList(Int64 userId);
}
