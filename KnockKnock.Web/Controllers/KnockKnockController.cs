using KnockKnock.Web.Interfaces;
using KnockKnock.Web.Services.Triangle.Models;
using System;
using System.Web.Http;
using KnockKnock.Web.Services.Reverse;

namespace KnockKnock.Web.Controllers
{
    public class KnockKnockController : ApiController
    {
        private readonly IFibonacciService _fibonacciService;
        private readonly IReverseWordsService _reverceWorksService;
        private readonly ITriangleService _triangleService;

        public KnockKnockController(IFibonacciService service, IReverseWordsService reverceWorksService, ITriangleService triangleService)
        {
            _fibonacciService = service;
            _reverceWorksService = reverceWorksService;
            _triangleService = triangleService;
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
        [HttpGet]
        [Route("api/Fibonacci")]
        public IHttpActionResult CanculateFibonacci(long n)
        {
            try
            {
                var result = _fibonacciService.GetNumber(n);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <summary>
        /// Reverse eache word in sentence
        /// </summary>
        /// <exception cref="MaxLengthException">
        /// Will be throw if input sentence string is so long
        /// </exception> 
        /// <param name="sentence">The sentence to reverse</param>
        /// <returns>Reversed sentence</returns>
        [HttpGet]
        [Route("api/ReverseWords")]
        public IHttpActionResult ReverseWordsInSentence(string sentence)
        {
            try
            {
                var result = _reverceWorksService.ReverseWords(sentence);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// The triangle service for return the type of triange given the lengths of its sides.
        /// For calculate the type of triangle used <b>Chain of responsibility</b> pattern <seealso cref="https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern"/>
        /// Writed from: <see cref="https://en.wikipedia.org/wiki/Triangle#Similarity_and_congruence"/>
        /// Possible types: <see cref="TriangleType"/>
        /// </summary>
        /// <param name="a">The length of side a</param>
        /// <param name="b">The length of side b</param>
        /// <param name="c">The length of side c</param>
        /// <returns>The type of triangle: <see cref="TriangleType"/></returns>
        [HttpGet]
        [Route("api/TriangleType")]
        public IHttpActionResult CalculateTheTriangleType(int a, int b, int c)
        {
            try
            {
                var triangle = new Triangle(a, b, c);
                var result = _triangleService.GetTriangleType(triangle);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get your token.
        /// </summary>
        /// <returns>Your token</returns>
        [HttpGet]
        [Route("api/Token")]
        public IHttpActionResult ReturnMyCurrentToken()
        {
            try
            {
                var result = new Guid("998d1f95-93f2-4ea7-9a3f-e3ce80638b51");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
