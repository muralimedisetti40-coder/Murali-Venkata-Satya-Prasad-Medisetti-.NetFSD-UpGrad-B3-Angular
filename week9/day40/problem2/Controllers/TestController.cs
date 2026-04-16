using Microsoft.AspNetCore.Mvc;
using WebApplication9.API.Exceptions;

namespace WebApplication9.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("error")]
        public IActionResult GetError()
        {
            throw new Exception("This is a test exception");
        }

        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            throw new NotFoundException("Contact not found");
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            throw new BadRequestException("Invalid request");
        }
    }
}