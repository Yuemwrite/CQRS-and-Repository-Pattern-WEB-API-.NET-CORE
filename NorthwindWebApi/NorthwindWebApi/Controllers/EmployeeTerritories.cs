using Business.Handlers.EmployeeTerritories.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EmployeeTerritories : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        return Ok(await Mediator.Send(new GetEmployeeTerritoriesQuery()));
    }
}
