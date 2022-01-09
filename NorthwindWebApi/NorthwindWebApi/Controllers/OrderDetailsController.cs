using Business.Handlers.OrderDetails.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class OrderDetailsController : BaseApiController
{
    [HttpGet("OrderWithProduct")]
    public async Task<IActionResult> GetOrderWithProductList()
    {
        return Ok(await Mediator.Send(new GetOrderWithProductQuery()));
    }

    [HttpGet("CustomerWithProduct")]
    public async Task<IActionResult> GetCustomerWithProductList()
    {
        return Ok(await Mediator.Send(new GetCustomerWithProductQuery()));
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllQuery()));
    }
}
