using FizzBuzz.Services;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    { 
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public ActionResult<List<List<string>>> ProcessFizzBuzz([FromBody] object?[] objects)
        {
            try
            {
                if (objects == null || objects.Length == 0)
                {
                    return BadRequest("Input array cannot be null or empty");
                }
                var ProcessFizzBuzzResult = _fizzBuzzService.ProcessFizzBuzz(objects);
                return Ok(ProcessFizzBuzzResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
