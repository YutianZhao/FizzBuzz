using FizzBuzz.Services;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    { 
        private readonly IFizzBuzzService _fizzBuzzService;

        /// <summary>
        /// Controller Constructor
        /// </summary>
        /// <param name="fizzBuzzService">Service to process</param>
        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        /// <summary>
        /// Process FizzBuzz endpoint
        /// </summary>
        /// <param name="objects">An array of any type</param>
        /// <returns>A list of result</returns>
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
