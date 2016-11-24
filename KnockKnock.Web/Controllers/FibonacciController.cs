using System;
using System.Web.Http;
using KnockKnock.Web.Interfaces;

namespace KnockKnock.Web.Controllers
{
    /// <summary>
    /// The controller for work with Fibonacci sequence
    /// </summary>
    public class FibonacciController : ApiController
    {
        private readonly IFibonachiService _service;
        public FibonacciController(IFibonachiService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns the nth number in the fibonacci sequence.
        /// </summary>
        /// <remarks>
        /// This will be using <b>Binet formula</b>, you can use negatives and positives numbers. 
        /// You can't use <see cref="n"/> more or less that 92, this is limitations for Int64
        /// </remarks>
        /// <param name="n">
        /// The index (n) of the fibonacci sequence
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Value cannot be greater than 92 for Int64. The error is logged on the server.
        /// </exception>
        /// <returns>Fibonacci number as long</returns>
        public IHttpActionResult Get(long n)
        {
            try
            {
                var result = _service.GetNumber(n);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
