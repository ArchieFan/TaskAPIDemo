using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPIDemo.Controllers
{
    [Route("api/[controller]/{name}")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        [HttpGet]
        public string GetGreetings(string name)
        {
            return $"Hello {name}, Welcome to Web API";
        }
    }
}
