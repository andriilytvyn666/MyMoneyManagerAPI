using System.ComponentModel.DataAnnotations;

namespace MyMoneyManagerApi.Models;

public enum OperationType { Expense, Income }
public enum OperationCategory { Food, Transport, Entertainment }

public class Operation
{
    [Key]
    [Required]
    public Int64 OperationId { get; set; }

    [Required]
    public Int64 NotebookId { get; set; }

    [Required]
    public Notebook Notebook { get; set; } = new();

    [Required]
    [MinLength(4)]
    [MaxLength(32)]
    public String Name { get; set; } = String.Empty;

    [Required]
    public Decimal Amount { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    [EnumDataType(typeof(OperationType))]
    public OperationType Type { get; set; }

    [Required]
    [EnumDataType(typeof(OperationCategory))]
    public OperationCategory Category { get; set; }
}
