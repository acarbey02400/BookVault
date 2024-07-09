
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {    
            UpdateUserDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetByIdUserQuery query)
        {
            UserGetByIdDto result = await Mediator.Send(query);
            return Created("", result);
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] GetListUserQuery query)
        {
            UserListModel result = await Mediator.Send(query);
            return Created("", result);
        }
    }
}
