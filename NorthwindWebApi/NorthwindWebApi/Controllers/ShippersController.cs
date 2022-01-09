using Business.Handlers.Shippers.Commands;
using Business.Handlers.Shippers.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetShipperList()
        {
            return Ok(await Mediator.Send(new GetShippersQuery()));
        }

        [HttpGet("{shipperId}")]
        public async Task<IActionResult> GetProductId(int shipperId)
        {
            return Ok(await Mediator.Send(new GetShipperQuery() { ShipperId = shipperId }));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateShipperCommand createShipperCommand)
        {
            return Created("", await Mediator.Send(createShipperCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateShipperCommand updateShipperCommand)
        {
            return Ok(await Mediator.Send(updateShipperCommand));
        }

    }
}
