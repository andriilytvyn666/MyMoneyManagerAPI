using System.ComponentModel.DataAnnotations;

namespace MyMoneyManagerApi.Models;

/// <summary>
/// User privilege levels enum
/// </summary>
public enum UserPrivileges
{
    /// <summary>
    /// Admin privileges
    /// </summary>
    Admin,
    /// <summary>
    /// Regular privileges
    /// </summary>
    Regular
};

/// <summary>
/// User model
/// </summary>
public class User
{
    /// <summary>
    /// User's Id
    /// </summary>
    [Key]
    [Required]
    public Int64 UserId { get; set; }

    /// <summary>
    /// User's username
    /// </summary>
    [Required]
    [MinLength(4)]
    [MaxLength(16)]
    public String UserName { get; set; } = String.Empty;

    /// <summary>
    /// User's full name
    /// </summary>
    [Required]
    [MinLength(4)]
    [MaxLength(32)]
    public String FullName { get; set; } = String.Empty;

    /// <summary>
    /// User's password
    /// </summary>
    [Required]
    [MinLength(8)]
    [MaxLength(64)]
    public String Password { get; set; } = String.Empty;

    /// <summary>
    /// User's email
    /// </summary>
    [Required]
    [EmailAddress]
    public String Email { get; set; } = String.Empty;

    /// <summary>
    /// User's privilege level
    /// </summary>
    [Required]
    [EnumDataType(typeof(UserPrivileges))]
    public UserPrivileges Privileges { get; set; }
}
