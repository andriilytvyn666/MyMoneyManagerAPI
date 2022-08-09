using Microsoft.AspNetCore.Mvc;
using MyMoneyManagerApi.Models;
using System.Net.Mime;

namespace MyMoneyManagerApi.Controllers;

/// <summary>
/// Operation API controller
/// </summary>
[ApiController]
[Route("api/operation")]
[Produces(MediaTypeNames.Application.Json)]
public class OperationController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    /// <summary>
    /// OperationController contsructor
    /// </summary>
    public OperationController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Add Operation to Notebook
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Operation> AddOperation([FromBody] Operation operation)
    {
        Notebook notebook;

        using (DatabaseContext db = new())
        {
            try
            {
                notebook = db.Notebooks.Where(notebook => notebook.NotebookId == operation.NotebookId).First();
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }

            db.Operations.Add(operation);
            db.SaveChanges();
        }
        return CreatedAtAction(nameof(GetOperation), new { id = operation.OperationId }, operation);
    }

    /// <summary>
    /// Get Operation by its OperationId
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Operation> GetOperation([FromRoute] Int64 id)
    {
        Operation operation;

        using (DatabaseContext db = new())
        {
            try
            {
                operation = db.Operations.Where(operation => operation.OperationId == id).First();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        return operation;
    }

    /// <summary>
    /// Get Operations list by NotebookId
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Operation>> GetOperationsList([FromQuery] Int64 notebookId)
    {
        List<Operation> operations;


        using (DatabaseContext db = new())
        {
            try
            {
                operations = db.Operations.Where(operation => operation.NotebookId == notebookId).ToList();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        return operations;
    }

    /// <summary>
    /// Update Operation
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Operation> UpdateOperation([FromRoute] Int64 id, [FromBody] Operation operation)
    {
        Operation currentOperation;

        using (DatabaseContext db = new())
        {

            try
            {
                currentOperation = db.Operations.Where(operation => operation.OperationId == id).First();
            }
            catch (InvalidOperationException)
            {
                return NotFound();


            }

            currentOperation.Name = operation.Name;
            currentOperation.Date = operation.Date;
            currentOperation.Amount = operation.Amount;
            currentOperation.Type = operation.Type;
            currentOperation.Category = operation.Category;

            db.SaveChanges();
        }

        return operation;
    }

    /// <summary>
    /// Remove Operation from Notebook 
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Operation> RemoveOperation([FromRoute] Int64 id)
    {
        Operation operation;

        using (DatabaseContext db = new())
        {
            try
            {
                operation = db.Operations.Where(operation => operation.OperationId == id).First();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            db.Remove(operation);
            db.SaveChanges();
        }

        return operation;
    }
}
