using Microsoft.AspNetCore.Mvc;
using MyMoneyManagerApi.Models;
using System.Net.Mime;

namespace MyMoneyManagerApi.Controllers;

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<User> PostUser([FromBody] User user)
    {
        using (DatabaseContext db = new())
        {
            db.Add(user);
            db.SaveChanges();
        }

        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }
}
