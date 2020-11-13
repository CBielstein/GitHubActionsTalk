using Microsoft.AspNetCore.Mvc;

namespace Hello.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello, SeaGL";
        }
    }
}
