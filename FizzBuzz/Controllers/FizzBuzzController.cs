using FizzBuzz.Services;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly ILogger<FizzBuzzController> _logger;
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(ILogger<FizzBuzzController> logger, IFizzBuzzService fizzBuzzService)
        {
            _logger = logger;
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public ActionResult<List<List<string>>> ProcessFizzBuzz([FromBody] object[] objects)
        {
            if (objects == null || objects.Length == 0)
            {
                return BadRequest("Input array cannot be null or empty");
            }
            var ProcessFizzBuzzResult = _fizzBuzzService.ProcessFizzBuzz(objects);
            return Ok(ProcessFizzBuzzResult);
        }
    }
}
