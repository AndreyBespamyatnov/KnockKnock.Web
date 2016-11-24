using System;
using System.Web.Http;
using KnockKnock.Web.Interfaces;
using KnockKnock.Web.Services.Triangle.Models;

namespace KnockKnock.Web.Controllers
{
    /// <summary>
    /// The controller for calculate the triangle type
    /// </summary>
    public class TriangleTypeController : ApiController
    {
        private readonly ITriangleService _service;
        public TriangleTypeController(ITriangleService service)
        {
            _service = service;
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
        public IHttpActionResult Get(int a, int b, int c)
        {
            try
            {
                var triangle = new Triangle(a, b, c);
                var result = _service.GetTriangleType(triangle);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
