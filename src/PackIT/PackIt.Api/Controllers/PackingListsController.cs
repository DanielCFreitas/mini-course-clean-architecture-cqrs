using Microsoft.AspNetCore.Mvc;
using PackIt.Application.Commands;
using PackIt.Application.DTO;
using PackIt.Application.Queries;
using PackIt.Shared.Abstractions.Commands;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Api.Controllers;

public class PackingListsController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public PackingListsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromQuery] SearchPackingLists query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePackingListWithItems command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
    }
    
    [HttpPut("{packingListId}/items")]
    public async Task<IActionResult> Put([FromBody] AddPackingItem command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
    
    [HttpPut("{packingListId:guid}/items/{name}/pack")]
    public async Task<IActionResult> Put([FromBody] PackItem command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
    
    [HttpDelete("{packingListId:guid}/items/{name}/pack")]
    public async Task<IActionResult> Delete([FromBody] RemovePackingItem command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
    
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] DeletePackingList command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}