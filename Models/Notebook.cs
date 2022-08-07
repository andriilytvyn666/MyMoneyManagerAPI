using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoneyManagerApi.Models;

public class Notebook
{
    [Key]
    [Required]
    public Int64 NotebookId { get; set; }

    [Required]
    public User User { get; set; } = new();

    [Required]
    public Int64 UserId { get; set; }

    [Required]
    [MinLength(4)]
    [MaxLength(32)]
    public String Name { get; set; } = String.Empty;

    [Required]
    public Decimal Amount { get; set; }

    [Required]
    public DateTime DateTimeCreated { get; set; }

    [Required]
    [InverseProperty("Notebook")]
    public List<Operation> Operations { get; } = new();
}
