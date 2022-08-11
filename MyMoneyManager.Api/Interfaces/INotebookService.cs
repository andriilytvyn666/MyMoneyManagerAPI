using MyMoneyManagerApi.Models;

namespace MyMoneyManagerApi.Interfaces;

interface INotebookService
{
    public Notebook Create(Notebook notebook);
    public Notebook Read(Notebook notebook);
    public Notebook Read(Int64 notebookId);
    public Notebook Update(Notebook notebook);
    public Notebook Delete(Notebook notebook);

    public List<Notebook> GetNotebooksList(Int64 userId);
    public List<Notebook> GetNotebooksList(User user);
}
