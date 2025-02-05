
using Application.Commons.Responses;
using Application.TaskLists.Commands.CreateTsksListCommand;
using Application.TaskLists.Commands.CreateTsksListCommand.Dtos;
using Application.TaskLists.Commands.DeleteTaskListCommand;
using Application.TaskLists.Commands.DeleteTaskListCommand.Dto;
using Application.TaskLists.Commands.UpdateTaskListCommand;
using Application.TaskLists.Commands.UpdateTaskListCommand.Dto;
using Application.TaskLists.Queries.GetAllTaskLists;
using Application.TaskLists.Queries.GetAllTaskListWithCompletedTasks;
using Application.TaskLists.Queries.GetMyTaskLists;
using Application.TaskLists.Queries.GetTaskListById;
using Application.TaskLists.Queries.GetTaskListInformation;
using Application.TaskLists.Queries.GetTaskListInformation.Dto;

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

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new(null, false, "User not found");

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


        [HttpGet("getTaskListById/{id}")]
        public async Task<IActionResult> getTaskListById(int id)
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var query = new GetTaskListByIdQuery(UserSubProvider, id);

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

        [HttpPut("updateTaskList")]
        public async Task<IActionResult> updateTaskList([FromBody] UpdateTaskListDto updateTaskListDto)
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var command = new UpdateTaskListCommand(updateTaskListDto, UserSubProvider);

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

        [HttpDelete("deleteTaskList")]
        public async Task<IActionResult> deleteTaskList([FromBody] DeleteTaskListDto deleteTaskListDto)
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var command = new DeleteTaskListCommand(deleteTaskListDto, UserSubProvider);

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




        [HttpGet("getTaskListInformation")]
        public async Task<IActionResult> getTaskListInformation()
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var query = new GetTaskListInformationQuery(new GetTaskListsInformationDto { UserSubProvider = UserSubProvider });

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


        [HttpGet("getTaskListWithTasks")]
        public async Task<IActionResult> getTaskListWithTasks(int Id)
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var query = new GetAllTaskListsQuery(UserSubProvider);

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

        [HttpGet("getTaskListWithCompletedTasks")]
        public async Task<IActionResult> getTaskListWithCompletedTasks(int Id)
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var query = new GetAllTaskListWithCompletedTasksQuery(UserSubProvider);

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


        [HttpGet("getMyTaskLists")]
        public async Task<IActionResult> getMyTaskLists()
        {
            try
            {
                string UserSubProvider = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (UserSubProvider == null)
                {
                    BaseResponse<string> badResponse = new BaseResponse<string>(null, false, "User not found");

                    return BadRequest(badResponse);
                }

                var query = new GetMyTaskListsQuery(UserSubProvider);

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