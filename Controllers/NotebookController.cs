using Microsoft.AspNetCore.Mvc;
using MyMoneyManagerApi.Models;
using System.Net.Mime;

namespace MyMoneyManagerApi.Controllers;

/// <summary>
/// Notebook API controller
/// </summary>
[ApiController]
[Route("api/notebook")]
[Produces(MediaTypeNames.Application.Json)]
public class NotebookController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    /// <summary>
    /// NotebookController contsructor
    /// </summary>
    public NotebookController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Create Notebook
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<Notebook> CreateNotebook([FromBody] Notebook notebook)
    {
        User user;

        using (DatabaseContext db = new())
        {
            try
            {
                user = db.Users.Where(user => user.UserId == notebook.UserId).First();
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }

            db.Notebooks.Add(notebook);
            db.SaveChanges();
        }

        return CreatedAtAction(nameof(GetNotebook), new { id = notebook.NotebookId }, notebook);
    }

    /// <summary>
    /// Get Notebooks list by UserId
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Notebook>> GetNotebooksList([FromQuery] Int64 userId)
    {
        List<Notebook> notebooks;


        using (DatabaseContext db = new())
        {
            try
            {
                notebooks = db.Notebooks.Where(notebook => notebook.UserId == userId).ToList();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        return notebooks;
    }

    /// <summary>
    /// Get Notebook by its NotebookId
    /// </summary>
    [HttpGet("{id}")]
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
    /// Update Notebook
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Notebook> UpdateNotebook([FromRoute] Int64 id, [FromBody] Notebook notebook)
    {
        using (DatabaseContext db = new())
        {
            Notebook currentNotebook;

            try
            {
                currentNotebook = db.Notebooks.Where(notebook => notebook.NotebookId == id).First();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            currentNotebook.UserId = notebook.UserId;
            currentNotebook.Name = notebook.Name;
            currentNotebook.Amount = notebook.Amount;

            db.SaveChanges();
        }


        return notebook;
    }

    /// <summary>
    /// Delete Notebook
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Notebook> DeleteNotebook([FromRoute] Int64 id)
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

            db.Remove(notebook);
            db.SaveChanges();
        }

        return notebook;
    }
}
