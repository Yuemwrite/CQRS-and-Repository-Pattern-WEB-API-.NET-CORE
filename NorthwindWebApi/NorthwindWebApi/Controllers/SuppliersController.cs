using Business.Handlers.Suppliers.Commands;
using Business.Handlers.Suppliers.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuppliersController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetSuppliersList()
    {
        return Ok(await Mediator.Send(new GetSuppliersQuery()));
    }

    [HttpGet("{supplierId}")]
    public async Task<IActionResult> GetSupplier(int supplierId)
    {
        return Ok(await Mediator.Send(new GetSupplierQuery() { SupplierId = supplierId }));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSupplierCommand createSupplierCommand)
    {
        return Created("", await Mediator.Send(createSupplierCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSupplierCommand updateSupplierCommand)
    {
        return Ok(await Mediator.Send(updateSupplierCommand));
    }

}
