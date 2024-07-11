using Application.Features.BookNotes.Commands.Create;
using Application.Features.BookNotes.Dtos;
using Application.Features.BookNotes.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookNotesController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBookNoteCommand command)
        {
            CreateBookNoteDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdBookNoteQuery query)
        {
            BookNoteGetByIdDto result = await Mediator.Send(query);
            return Created("", result);
        }
    }
}
