using Microsoft.AspNetCore.Mvc;
using MyMoneyManagerApi.Models;
using System.Net.Mime;

namespace MyMoneyManagerApi.Controllers;

/// <summary>
/// User API controller
/// </summary>
[ApiController]
[Route("api/user/")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    /// <summary>
    /// UserController contsructor
    /// </summary>
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Create User
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        using (DatabaseContext db = new())
        {
            db.Add(user);
            db.SaveChanges();
        }

        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }

    /// <summary>
    /// Get User by its Id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<User> GetUser([FromRoute] Int64 id)
    {
        User user;

        using (DatabaseContext db = new())
        {
            try
            {
                user = db.Users.Where(user => user.UserId == id).First();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        return user;
    }

    /// <summary>
    /// Get Users list
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<User>> GetUsers()
    {
        List<User> users;

        using (DatabaseContext db = new())
        {
            users = db.Users.ToList();
        }

        return users;
    }

    /// <summary>
    /// Update User
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> UpdateUser([FromRoute] Int64 id, [FromBody] User user)
    {
        using (DatabaseContext db = new())
        {
            User currentUser;

            try
            {
                currentUser = db.Users.Where(user => user.UserId == id).First();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            currentUser.UserName = user.UserName;
            currentUser.Email = user.Email;
            currentUser.Password = user.Password;
            currentUser.FullName = user.FullName;
            currentUser.Privileges = user.Privileges;

            db.SaveChanges();
        }


        return user;
    }

    /// <summary>
    /// Delete User
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> DeleteUser([FromRoute] Int64 id)
    {
        User user;

        using (DatabaseContext db = new())
        {
            try
            {
                user = db.Users.Where(user => user.UserId == id).First();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            db.Remove(user);
            db.SaveChanges();
        }

        return user;
    }
}
