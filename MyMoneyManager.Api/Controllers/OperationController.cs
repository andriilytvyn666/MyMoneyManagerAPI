using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MyMoneyManager.Api.Interfaces;
using MyMoneyManager.Api.Models;

namespace MyMoneyManager.Api.Controllers;

/// <summary>
/// Operation API controller
/// </summary>
[ApiController]
[Route("api/operation")]
[Produces(MediaTypeNames.Application.Json)]
public class OperationController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IOperationService _operationService;

    public OperationController(ILogger<UserController> logger, IOperationService operationService)
    {
        _logger = logger;
        _operationService = operationService;
    }

    /// <summary>
    /// Add Operation to Notebook
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Operation> AddOperation([FromBody] Operation operation)
    {
        Operation createdOperation = _operationService.Create(operation);
        return CreatedAtAction(nameof(GetOperation), new { id = operation.OperationId }, operation);
    }

    /// <summary>
    /// Get Operation by OperationId
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<Operation> GetOperation([FromRoute] Int64 id)
    {
        return _operationService.Read(id);
    }

    /// <summary>
    /// Get Operations list by NotebookId
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<Operation>> GetOperationsList([FromQuery] Int64 id)
    {
        return _operationService.GetOperationsList(id);
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
        operation.OperationId = id;
        return _operationService.Update(operation);
    }

    /// <summary>
    /// Remove Operation from Notebook 
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Operation> RemoveOperation([FromRoute] Int64 id)
    {
        Operation operationToDelete = _operationService.Read(id);
        return _operationService.Delete(operationToDelete);
    }
}
