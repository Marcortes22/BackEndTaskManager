
using Application.Commons.Responses;
using Application.TaskLists.Commands.CreateTsksListCommand;
using Application.TaskLists.Commands.CreateTsksListCommand.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createTaskList")]
        public async Task<IActionResult> createTaskList([FromBody] CreateTaskListDto createTaskListDto)
        {
            try
            {

                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if(UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var command = new CreateTaskListCommand(createTaskListDto, UserSubProvider);

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
