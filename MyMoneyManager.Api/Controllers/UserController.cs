using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;
using MyMoneyManager.Api.Services;

namespace MyMoneyManager.Api.Controllers;

/// <summary>
/// User API controller
/// </summary>
[ApiController]
[Route("api/user/")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
        _userService = UserService.Instance;
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
        User createdUser = _userService.Create(user);
        return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
    }

    /// <summary>
    /// Get User by UserId
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<User> GetUser([FromRoute] Int64 id)
    {
        return _userService.Read(id);
    }

    /// <summary>
    /// Get Users list
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<User>> GetUsersList()
    {
        return _userService.GetUsersList();
    }

    /// <summary>
    /// Update User
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<User> UpdateUser([FromRoute] Int64 id, [FromBody] User user)
    {
        user.UserId = id;
        return _userService.Update(user);
    }

    /// <summary>
    /// Delete User
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<User> DeleteUser([FromRoute] Int64 id)
    {
        User user = _userService.Read(id);
        return _userService.Delete(user);
    }
}
