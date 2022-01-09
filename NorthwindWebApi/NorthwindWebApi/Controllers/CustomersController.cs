
using Business.Handlers.Customers.Commands;
using Business.Handlers.Products.Commands;
using Business.Handlers.Products.Queries;
using Business.Handlers.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await Mediator.Send(new GetCustomersQuery()));
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomerId(string customerId)
        {
            return Ok(await Mediator.Send(new GetCustomerQuery() { CustomerId = customerId}));
        }

        

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            return Ok(await Mediator.Send(updateCustomerCommand));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            return Created("", await Mediator.Send(createCustomerCommand));
        }
    }
}
