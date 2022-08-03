using FinalProject.Application.Features.UserFeatures.Commands.CheckUser;
using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using FinalProject.Application.Wrappers.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            BaseResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> CheckUser([FromBody] CheckUserCommandRequest request)
        {
            CheckUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
