
using Application.Commons.Responses;
using Application.Users.Commands.CreateUserCommand;
using Application.Users.Commands.CreateUserCommand.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("verifyAccound")]
        public async Task<IActionResult> verifyAccound()
        {
            try
            {

            var token = await HttpContext.GetTokenAsync("access_token");

                if (token == null)
                {
                    BaseResponse<string> badResponse = new (null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var command = new CreateUserCommand(new CreateUserDto(token));

            var response = await _mediator.Send(command);

            if (response.Success)
            {
            return Ok(response);

            }
            return BadRequest(response);

            }
            catch (Exception e)
            {
                BaseResponse<string> badResponse = new BaseResponse<string>(null, false, $"Error: {e.Message}");

                return BadRequest(badResponse);
            }

        }
    }
}
