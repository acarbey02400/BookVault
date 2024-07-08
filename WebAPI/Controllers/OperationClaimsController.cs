using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        //[HttpPost]
        //public async Task<ActionResult> Add([FromBody] CreateOperationClaimCommand command)
        //{
        //    CreateOperationClaimDto createOperationClaimDto = await Mediator.Send(command);
        //    return Created("", createOperationClaimDto);
        //}
    }
}
