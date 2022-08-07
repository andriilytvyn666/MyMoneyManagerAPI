using Microsoft.AspNetCore.Mvc;
using mymoneymanager_api.Models;
using System.Net.Mime;

namespace mymoneymanager_api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public User GetUser([FromRoute] Int64 id)
    {
        User user = new(id, "testuser", "Test User", "supersecret", "example@example.com", UserPrivileges.Regular);

        return user;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<User> PostUser([FromBody] User user)
    {
        if (user.UserId == 10)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }
}
