using System;
using System.Web.Http;
using KnockKnock.Web.Interfaces;
using KnockKnock.Web.Services.Reverse;

namespace KnockKnock.Web.Controllers
{
    /// <summary>
    /// The controller for reverse words in the sentence
    /// </summary>
    public class ReverseWordsController : ApiController
    {
        private readonly IReverseWordsService _service;
        public ReverseWordsController(IReverseWordsService service)
        {
            _service = service;
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
        public IHttpActionResult Get(string sentence)
        {
            try
            {
                var result = _service.ReverseWords(sentence);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
