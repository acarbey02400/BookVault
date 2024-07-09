using Application.Features.Books.Commands.Create;
using Application.Features.Books.Commands.Update;
using Application.Features.Books.Dtos;
using Application.Features.Books.Models;
using Application.Features.Books.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CreateBookCommand command)
        {
            CreateBookDto result = await Mediator.Send(command);
            return Created("",result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand command)
        {
            UpdateBookDto result = await Mediator.Send(command);
            return Created("",result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById([FromQuery]GetByIdBookQuery query)
        {
            BookGetByIdDto result=await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] GetListBookQuery query)
        {
            BookListModel result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("getdynamiclist")]
        public async Task<IActionResult> GetDynamicList([FromQuery] GetListBookDynamicQuery query)
        {
            BookListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
