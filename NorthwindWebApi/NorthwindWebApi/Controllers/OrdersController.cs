
using Business.Handlers.Orders.Commands;
using Business.Handlers.Orders.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetOrderList()
        {
            return Ok(await Mediator.Send(new GetOrdersQuery()));
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetProductId(int orderId)
        {
            return Ok(await Mediator.Send(new GetOrderQuery { OrderId = orderId }));
        }

        [HttpGet("withShipper")]
        public async Task<IActionResult> GetWithShipper()
        {
            return Ok(await Mediator.Send(new GetOrdersWithShipperQuery()));
        }

        [HttpGet("withEmployee")]
        public async Task<IActionResult> GetWithEmployee()
        {
            return Ok(await Mediator.Send(new GetOrdersWithEmployeeQuery()));
        }

        [HttpGet("withShipperEmployee")]
        public async Task<IActionResult> GetOrderWithShipperEmployee()
        {
            return Ok(await Mediator.Send(new GetrOrderShipperEmployeeQuery()));
        }

        [HttpGet("withCustomer")]
        public async Task<IActionResult> GetOrderWithCustomer()
        {
            return Ok(await Mediator.Send(new GetOrderWithCustomerQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand createOrderCommand)
        {
            return Created("", await Mediator.Send(createOrderCommand));
        }


    }
}
