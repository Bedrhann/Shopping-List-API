using FinalProject.Application.Features.UserFeatures.Queries.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FinalProject.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ResponseCache(Duration = 500, VaryByQueryKeys = new string[] { "Page", "Limit", })]
        public async Task<IActionResult> GetAllUsers([FromQuery]GetAllUserQueryRequest request)
        {
            GetAllUserQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.Users);
        }

    }
}
