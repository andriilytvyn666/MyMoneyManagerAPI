using System.ComponentModel.DataAnnotations;

namespace mymoneymanager_api.Models;

public enum OperationType { Expense, Income }
public enum OperationCategory { Food, Transport, Entertainment }

public class Operation
{
    [Required]
    public Int64 OperationId { get; set; }

    [Required]
    public Int64 NotebookId { get; set; }

    [MinLength(4)]
    [MaxLength(32)]
    [Required]
    public String Name { get; set; }

    [Required]
    public Decimal Amount { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [EnumDataType(typeof(OperationType))]
    [Required]
    public OperationType Type { get; set; }

    [EnumDataType(typeof(OperationCategory))]
    [Required]
    public OperationCategory Category { get; set; }

    public Operation()
    {
        OperationId = default;
        NotebookId = default;
        Name = "0000";
        Amount = default;
        Date = default;
        Type = default;
        Category = default;
    }

    public Operation(Int64 operationId, Int64 notebookId, String name, Decimal amount, DateOnly date, OperationType type, OperationCategory category)
    {
        OperationId = operationId;
        NotebookId = notebookId;
        Name = name;
        Amount = amount;
        Date = date;
        Type = type;
        Category = category;
    }
}
