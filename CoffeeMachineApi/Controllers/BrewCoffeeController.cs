using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CoffeeMachineApi.Controllers
{
    [ApiController]
    [Route("")]
    public class BrewCoffeeController : ControllerBase
    {
        private static int _callCount = 0;

        [HttpGet("brew-coffee")]
        public IActionResult BrewCoffee()
        {
            var count = Interlocked.Increment(ref _callCount);
            var now = DateTime.Now;

            if (now.Month == 4 && now.Day == 1)
            {
                return StatusCode(418, "I’m a teapot");
            }

            if (count % 5 == 0)
            {
                return StatusCode(503, "Service Unavailable");
            }

            return Ok(new
            {
                message = "Your piping hot coffee is ready",
                prepared = DateTimeOffset.Now.ToString("o")
            });
        }
    }
}
