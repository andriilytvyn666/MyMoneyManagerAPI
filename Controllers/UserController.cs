using Microsoft.AspNetCore.Mvc;
using MyMoneyManagerApi.Models;
using System.Net.Mime;

namespace MyMoneyManagerApi.Controllers;

/// <summary>
/// User API controller
/// </summary>
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
    /// Create Notebook
    /// </summary>
    [HttpPost("Notebook")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<Notebook> CreateNotebook([FromBody] Notebook notebook)
    {
        using (DatabaseContext db = new())
        {
            db.Notebooks.Add(notebook);
            db.SaveChanges();
        }

        return CreatedAtAction(nameof(GetNotebook), new { id = notebook.NotebookId }, notebook);
    }

    /// <summary>
    /// Get Notebook by its Id
    /// </summary>
    [HttpGet("Notebook/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Notebook> GetNotebook([FromRoute] Int64 id)
    {
        Notebook notebook;

        using (DatabaseContext db = new())
        {
            try
            {
                notebook = db.Notebooks.Where(notebook => notebook.NotebookId == id).First();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        return notebook;
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
}
