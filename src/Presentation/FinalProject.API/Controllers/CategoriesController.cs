using FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList;
using FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory;
using FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using FinalProject.Application.Wrappers.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using MediatR;
using FinalProject.Application.Features.CategoryFeatures.Queries.GetCategoryById;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoryByShopList([FromQuery] GetAllCategoryByShopListQueryRequest request)
        {

            GetAllCategoryByShopListQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.Categories);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryByIdQueryRequest request)
        {
            GetCategoryByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response.Category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            BaseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommandRequest request)
        {
            BaseResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
