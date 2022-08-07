using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoneyManagerApi.Models;

public enum UserPrivileges { Admin, Regular };

public class User
{
    [Key]
    [Required]
    [ForeignKey("UserId")]
    public Int64 UserId { get; set; }

    [Required]
    [MinLength(4)]
    [MaxLength(16)]
    public String UserName { get; set; } = String.Empty;

    [Required]
    [MinLength(4)]
    [MaxLength(32)]
    public String FullName { get; set; } = String.Empty;

    [Required]
    [MinLength(8)]
    [MaxLength(64)]
    public String Password { get; set; } = String.Empty;

    [Required]
    [EmailAddress]
    public String Email { get; set; } = String.Empty;

    [Required]
    [EnumDataType(typeof(UserPrivileges))]
    public UserPrivileges Privileges { get; set; }

    [Required]
    [InverseProperty("User")]
    public List<Notebook> Notebooks { get; } = new();
}
