
using Application.Features.BookShelfs.Commands.CreateBookShelfs;
using Application.Features.BookShelfs.Dtos;
using Application.Features.BookShelfs.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShelfsController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBookShelfCommand command)
        {
            CreateBookShelfDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdBookShelfQuery query)
        {
            GetByIdBookShelfDto result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
