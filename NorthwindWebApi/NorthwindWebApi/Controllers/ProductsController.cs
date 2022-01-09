
using Business.Handlers.Products.Commands;
using Business.Handlers.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetProductList()
    {
        return Ok(await Mediator.Send(new GetProductsQuery()));
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductId(int productId)
    {
        return Ok(await Mediator.Send(new GetProductQuery() { ProductId = productId }));
    }

    [HttpGet("withCategory")]
    public async Task<IActionResult> GetWithCategory()
    {
        return Ok(await Mediator.Send(new GetProductsWithCategoryQuery()));
    }

    [HttpGet("withSupplier")]
    public async Task<IActionResult> GetWithSupplier()
    {
        return Ok(await Mediator.Send(new GetProductsWithSupplierQuery()));
    }

    [HttpGet("withSupplierCategory")]
    public async Task<IActionResult> GetWithSupplierCategory()
    {
        return Ok(await Mediator.Send(new GetProductCategorySupplierQuery()));
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
    {
        return Created("", await Mediator.Send(createProductCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {
        return Ok(await Mediator.Send(updateProductCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProductCommand)
    {
        return Ok(await Mediator.Send(deleteProductCommand));
    }
}
