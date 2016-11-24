using System;
using System.Web.Http;

namespace KnockKnock.Web.Controllers
{
    /// <summary>
    /// User token controller
    /// </summary>
    public class TokenController : ApiController
    {
        /// <summary>
        /// Get your token.
        /// </summary>
        /// <returns>Your token</returns>
        public IHttpActionResult Get()
        {
            try
            {
                var result = Guid.Empty;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
