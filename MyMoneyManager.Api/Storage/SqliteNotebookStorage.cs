using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;

namespace MyMoneyManager.Api.Storage;

// TODO: Make all methods async
public class SqliteNotebookStorage : INotebookStorage
{
    private IServiceScopeFactory _scopeFactory;

    public SqliteNotebookStorage(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Notebook Create(Notebook notebook)
    {
        Notebook createdNotebook;

        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            // TODO: Throw exception when notebook with same NotebookId already exists
            createdNotebook = _db.Add(notebook).Entity;
            _db.SaveChanges();
        }

        return createdNotebook;
    }

    public Notebook Read(Int64 notebookId)
    {
        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            return _db.Notebooks.Single(x => x.NotebookId == notebookId);
        }
    }

    public List<Notebook> GetNotebooksList(Int64 userId)
    {
        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            // TODO: Throw exception if User is not found
            // User user = _db.Users.First(x => x.UserId == userId);

            List<Notebook> notebooks = _db.Notebooks.Where(x => x.UserId == userId).ToList();

            return notebooks;
        }
    }

    public Notebook Update(Notebook notebook)
    {
        Notebook updatedNotebook;

        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            updatedNotebook = _db.Notebooks.First(x => x.NotebookId == notebook.NotebookId);

            // TODO: Throw exception when unchangeable fields diffrent from ones in db
            updatedNotebook.Name = notebook.Name;
            updatedNotebook.Amount = notebook.Amount;

            _db.SaveChanges();
        }

        return updatedNotebook;
    }

    public Notebook Delete(Int64 notebookId)
    {
        using (ApplicationDbContext _db = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>())
        {
            // TODO: Throw exception when notebook is not found
            Notebook notebookToDelete = _db.Notebooks.First(x => x.NotebookId == notebookId);
            Notebook deletedNotebook = _db.Remove(notebookToDelete).Entity;
            _db.SaveChanges();

            return deletedNotebook;
        }
    }
}
