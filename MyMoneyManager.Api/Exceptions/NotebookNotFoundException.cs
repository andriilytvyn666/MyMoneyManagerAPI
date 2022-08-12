namespace MyMoneyManager.Api.Exceptions;

public class NotebookNotFoundException : Exception
{
    public NotebookNotFoundException(Int64 notebookId) : base($"Could not find notebook with Id \"${notebookId}\"") { }
}
