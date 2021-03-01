using Microsoft.AspNetCore.Mvc;

using Task_1.Domain;

namespace Task_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimesController : ControllerBase
    {
        private readonly IPrimesWorker _primesWorker;

        public PrimesController(IPrimesWorker primesWorker)
        {
            _primesWorker = primesWorker;
        }

        [HttpGet]
        [Route("{number:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult IsPrime([FromRoute] int number)
        {
            bool isPrime = _primesWorker.IsPrime(number);
            if (isPrime)
            {
                return Ok();
            }
            else
            {
                return NotFound("Requested number is not prime");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(int[]), 200)]
        [ProducesResponseType(400)]
        public ActionResult<int[]> PrimesInRange([FromQuery] int? from, [FromQuery] int? to)
        {
            if (!from.HasValue || !to.HasValue)
            {
                return BadRequest("Response status code: 400 | Bad Request | Both parameters 'from' and 'to' should be specified in query");
            }

            int[] primes = _primesWorker.FindPrimesInRange(from.Value, to.Value);

            return Ok(primes);
        }
    }
}
