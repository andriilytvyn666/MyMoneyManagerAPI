using Microsoft.AspNetCore.Mvc;
using MyMoneyManagerApi.Models;
using System.Net.Mime;

namespace MyMoneyManagerApi.Controllers;

/// <summary>
/// Notebook API 
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

}
