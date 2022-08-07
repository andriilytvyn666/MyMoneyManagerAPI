using System.ComponentModel.DataAnnotations;

namespace MyMoneyManagerApi.Models;

/// <summary>
/// Operation types enum
/// </summary>
public enum OperationType
{
    /// <summary>
    /// Expense operation type
    /// </summary>
    Expense,
    /// <summary>
    /// Income operation type
    /// </summary>
    Income
}

/// <summary>
/// Operation categories enum
/// </summary>
public enum OperationCategory { Food, Transport, Entertainment }

/// <summary>
/// Operation model
/// </summary>
public class Operation
{
    /// <summary>
    /// Id of the operation
    /// </summary>
    [Key]
    [Required]
    public Int64 OperationId { get; set; }

    /// <summary>
    /// Id of the Notebook to which operation belongs
    /// </summary>
    [Required]
    public Int64 NotebookId { get; set; }

    /// <summary>
    /// Name of the operation
    /// </summary>
    [Required]
    [MinLength(4)]
    [MaxLength(32)]
    public String Name { get; set; } = String.Empty;

    /// <summary>
    /// Amount of income or witdrawal commited with the operation
    /// </summary>
    [Required]
    public Decimal Amount { get; set; }

    /// <summary>
    /// Date when operation was performed at
    /// </summary>
    [Required]
    public DateOnly Date { get; set; }

    /// <summary>
    /// Operation type
    /// </summary>
    [Required]
    [EnumDataType(typeof(OperationType))]
    public OperationType Type { get; set; }

    /// <summary>
    /// Operation category
    /// </summary>
    [Required]
    [EnumDataType(typeof(OperationCategory))]
    public OperationCategory Category { get; set; }
}
