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
