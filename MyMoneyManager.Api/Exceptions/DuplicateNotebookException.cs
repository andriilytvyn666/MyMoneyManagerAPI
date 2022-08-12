namespace MyMoneyManager.Api.Exceptions;

public class DuplicateNotebookException : Exception
{
    public DuplicateNotebookException(Int64 notebookId) : base($"Notebook with Id \"{notebookId}\" already exists") { }
}
