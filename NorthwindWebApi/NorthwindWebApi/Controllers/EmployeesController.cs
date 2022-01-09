using Business.Handlers.Employees.Commands;
using Business.Handlers.Employees.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetEmployeeList()
    {
        return Ok(await Mediator.Send(new GetEmployeesQuery()));
    }

    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetEmployeeId(int employeeId)
    {
        return Ok(await Mediator.Send(new GetEmployeeQuery() { EmployeeId = employeeId }));
    }

    [HttpGet("withTerritories")]
    public async Task<IActionResult> GetEmployeeWithTerritories()
    {
        return Ok(await Mediator.Send(new GetEmployeeWithTerritoryQuery()));
    }

    [HttpPost]

    public async Task<IActionResult> Add([FromBody] CreateEmployeeCommand createEmployeeCommand)
    {
        return Created("", await Mediator.Send(createEmployeeCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand updateEmployeeCommand)
    {
        return Ok(await Mediator.Send(updateEmployeeCommand));
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteEmployeeCommand deleteEmployeeCommand)
    {
        return Ok(await Mediator.Send(deleteEmployeeCommand));
    }

}
