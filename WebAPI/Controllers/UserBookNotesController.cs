using Application.Features.BookNotes.Queries;
using Application.Features.UserBookNotes.Commands.CreateUserBookNotes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookNotesController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CreateUserBookNoteCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", command);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetById([FromQuery]GetByIdBookNoteQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> Create([FromQuery] GetListBookNoteQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
