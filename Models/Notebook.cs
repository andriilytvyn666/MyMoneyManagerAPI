using System.ComponentModel.DataAnnotations;

namespace mymoneymanager_api.Models;

public class Notebook
{
    [Required]
    public Int64 NotebookId { get; set; }

    [Required]
    public Int64 UserId { get; set; }

    [MinLength(4)]
    [MaxLength(32)]
    [Required]
    public String Name { get; set; }

    [Required]
    public Decimal Amount { get; set; }

    [Required]
    public DateTime DateTimeCreated { get; set; }

    public Notebook()
    {
        NotebookId = default;
        UserId = default;
        Name = "0000";
        Amount = default;
        DateTimeCreated = default;
    }

    public Notebook(Int64 notebookId, Int64 userId, String name, Decimal amount, DateTime dateTimeCreated)
    {
        NotebookId = notebookId;
        UserId = userId;
        Name = name;
        Amount = amount;
        DateTimeCreated = dateTimeCreated;
    }
}
