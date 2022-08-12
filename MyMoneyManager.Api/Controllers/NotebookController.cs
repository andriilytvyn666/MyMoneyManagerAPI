using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;
using MyMoneyManager.Api.Services;

namespace MyMoneyManager.Api.Controllers;

/// <summary>
/// Notebook API controller
/// </summary>
[ApiController]
[Route("api/notebook")]
[Produces(MediaTypeNames.Application.Json)]
public class NotebookController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly INotebookService _notebookService;

    public NotebookController(ILogger<UserController> logger)
    {
        _logger = logger;
        _notebookService = NotebookService.Instance;
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
        Notebook createdNotebook = _notebookService.Create(notebook);
        return CreatedAtAction(nameof(GetNotebook), new { id = createdNotebook.NotebookId }, createdNotebook);
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
        return _notebookService.GetNotebooksList(userId);
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
        return _notebookService.Read(id);
    }

    /// <summary>
    /// Update Notebook
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Notebook> UpdateNotebook([FromRoute] Int64 notebookId, [FromBody] Notebook notebook)
    {
        notebook.NotebookId = notebookId;
        return _notebookService.Update(notebook);
    }

    /// <summary>
    /// Delete Notebook
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Notebook> DeleteNotebook([FromRoute] Int64 notebookId)
    {
        Notebook notebookToDelete = _notebookService.Read(notebookId);
        return _notebookService.Delete(notebookToDelete);
    }
}
