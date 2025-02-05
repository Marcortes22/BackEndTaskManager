using Application.Commons.Responses;
using Application.TaskItems.Commands.CreateTaskItemCommand;
using Application.TaskItems.Commands.CreateTaskItemCommand.Dto;
using Application.TaskItems.Queries.GetCompletedTasks;
using Application.TaskItems.Queries.GetImportantTasks;
using Application.TaskItems.Queries.GetPlannedTasks;
using Application.TaskItems.Queries.GetTodayTasks;
using Application.TaskLists.Commands.CreateTsksListCommand.Dtos;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskItemController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTaskItem([FromBody] CreateTaskItemDto createTaskItemDto)
        {

            try
            {
                Console.WriteLine(createTaskItemDto.AddedToMyDay);

                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var command = new CreateTaskItemCommand(createTaskItemDto, UserSubProvider);

                var response = await _mediator.Send(command);


                if (response.Success) { 
                
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



        [HttpGet("GetMyDayTasks")]
        public async Task<IActionResult> GetMyDayTasks()
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var query = new GetTodayTasksQuery(UserSubProvider);

                var response = await _mediator.Send(query);

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

        [HttpGet("GetImportantTasks")]
        public async Task<IActionResult> GetImportantTasks()
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var query = new GetImportantTasksQuery(UserSubProvider);

                var response = await _mediator.Send(query);

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

        [HttpGet("GetPlannedTasks")]
        public async Task<IActionResult> GetPlannedTasks()
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var query = new GetPlannedTasksQuery(UserSubProvider);

                var response = await _mediator.Send(query);

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

        [HttpGet("GetCompletedTasks")]
        public async Task<IActionResult> GetCompletedTasks()
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var query = new GetCompletedTasksQuery(UserSubProvider);

                var response = await _mediator.Send(query);

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
