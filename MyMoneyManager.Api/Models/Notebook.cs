using System.ComponentModel.DataAnnotations;

namespace MyMoneyManager.Api.Models;

/// <summary>
/// Notebook model
/// </summary>
public class Notebook
{
    /// <summary>
    /// Id of the Notebook
    /// </summary>
    [Key]
    [Required]
    public Int64 NotebookId { get; set; }

    /// <summary>
    /// UserId of Notebook owner
    /// </summary>
    [Required]
    public Int64 UserId { get; set; }

    /// <summary>
    /// Name of the Notebook
    /// </summary>
    [Required]
    [MinLength(4)]
    [MaxLength(32)]
    public String Name { get; set; } = String.Empty;

    /// <summary>
    /// Amount of available money in the Notebook
    /// </summary>
    [Required]
    public Decimal Amount { get; set; }

    /// <summary>
    /// Dataa and time of Notebook creation
    /// </summary>
    [Required]
    public DateTime DateTimeCreated { get; set; }
}
