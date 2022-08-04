using System.ComponentModel.DataAnnotations;

namespace mymoneymanager_api.Models;

public enum UserPrivileges { Admin, Regular };

public class User
{
    [Required]
    public Int64 UserId { get; set; }

    [MinLength(4)]
    [MaxLength(16)]
    [Required]
    public String UserName { get; set; }

    [MinLength(4)]
    [MaxLength(32)]
    [Required]
    public String FullName { get; set; }

    [MinLength(8)]
    [MaxLength(64)]
    [Required]
    public String Password { get; set; }

    [EmailAddress]
    [Required]
    public String Email { get; set; }

    [EnumDataType(typeof(UserPrivileges))]
    [Required]
    public UserPrivileges Privileges { get; set; }

    public User()
    {
        UserId = default;
        UserName = "0000";
        FullName = "0000";
        Password = "00000000";
        Email = "example@example.com";
        Privileges = default;
    }

    public User(Int64 userId, String userName, String fullName, String password, String email, UserPrivileges privileges)
    {
        UserId = userId;
        UserName = userName;
        FullName = fullName;
        Password = password;
        Email = email;
        Privileges = privileges;
    }
}
