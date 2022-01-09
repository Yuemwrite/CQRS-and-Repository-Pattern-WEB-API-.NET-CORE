using Business.Handlers.Categories.Commands;
using Business.Handlers.Categories.Queries;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Controllers.BaseController;

namespace NorthwindWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await Mediator.Send(new GetCategoriesQuery()));
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByDepartmentId(int categoryId)
        {
            return Ok(await Mediator.Send(new GetCategoryQuery() { CategoryId = categoryId }));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            return Created("", await Mediator.Send(createCategoryCommand));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            return Ok(await Mediator.Send(updateCategoryCommand));
        }

       
    }
}
