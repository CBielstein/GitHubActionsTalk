using Microsoft.AspNetCore.Mvc;

namespace Hello.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Get([FromQuery] string name)
        {
            return "Hello, " + (name ?? "World");
        }
    }
}
