using Business.Handlers.Regions.Queries;
using Business.Handlers.Territories.Commands;
using Business.Handlers.Territories.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TerritoriesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetTerritoriesList()
    {
        return Ok(await Mediator.Send(new GetTerritoriesQuery()));
    }

    [HttpGet("{territoryId}")]
    public async Task<IActionResult> GetTerritoryId(string territoryId)
    {
        return Ok(await Mediator.Send(new GetTerritoryQuery() { TerritoryId = territoryId }));
    }

    [HttpGet("withTerritories")]
    public async Task<IActionResult> GetWithTerritories()
    {
        return Ok(await Mediator.Send(new GetRegionTerritoryQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTerritoryCommand createTerritoryCommand)
    {
        return Created("", await Mediator.Send(createTerritoryCommand));
    }
}
