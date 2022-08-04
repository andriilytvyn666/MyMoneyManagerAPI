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
    public User GetUser(Int64 id)
    {
        User testUser = new(id, "testuser", "Test User", "supersecret", "example@example.com", UserPrivileges.Regular);

        return testUser;
    }

    [HttpPost]
    public ActionResult<User> PostUser()
    {
        User testUser = new(0, "testuser", "Test User", "supersecret", "example@example.com", UserPrivileges.Regular);

        return CreatedAtAction(nameof(GetUser), new { id = testUser.UserId }, testUser);
    }
}
