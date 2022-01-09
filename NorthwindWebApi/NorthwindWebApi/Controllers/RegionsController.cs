
using Business.Handlers.Regions.Commands;
using Business.Handlers.Regions.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetRegionList()
    {
        return Ok(await Mediator.Send(new GetRegionsQuery()));
    }

    [HttpGet("{regionId}")]
    public async Task<IActionResult> GetRegionId(int regionId)
    {
        return Ok(await Mediator.Send(new GetRegionQuery { RegionId = regionId }));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRegionCommand createRegionCommand)
    {
        return Created("", await Mediator.Send(createRegionCommand));
    }

}
