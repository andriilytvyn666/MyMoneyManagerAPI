using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;
using MyMoneyManager.Api.Storage;

namespace MyMoneyManager.Api.Services;

public class NotebookService : INotebookService
{
    private INotebookStorage _storage;
    private static readonly Lazy<NotebookService> _lazy = new(() => new());
    public static NotebookService Instance { get { return _lazy.Value; } }

    private NotebookService()
    {
        _storage = SqliteNotebookStorage.Instance;
    }

    public Notebook Create(Notebook notebook)
    {
        return _storage.Create(notebook);
    }

    public Notebook Read(Notebook notebook)
    {
        return _storage.Read(notebook.NotebookId);
    }

    public Notebook Read(Int64 notebookId)
    {

        return _storage.Read(notebookId);
    }

    public Notebook Update(Notebook notebook)
    {
        return _storage.Update(notebook);
    }

    public Notebook Delete(Notebook notebook)
    {
        return _storage.Delete(notebook.NotebookId);
    }

    public List<Notebook> GetNotebooksList(Int64 userId)
    {
        return _storage.GetNotebooksList(userId);
    }

    public List<Notebook> GetNotebooksList(User user)
    {
        return GetNotebooksList(user.UserId);
    }
}
