using KnockKnock.Web.Services.Triangle.Models;

namespace KnockKnock.Web.Services.Triangle.Handlers
{
    /// <summary>
    /// One of calculating heandles, just validation
    /// </summary>
    internal class IsValid : TriangleHandler
    {
        /// <summary>
        /// Validate the triangle model by default rules
        /// <seealso cref="https://en.wikipedia.org/wiki/Triangle#Similarity_and_congruence"/>
        /// </summary>
        /// <param name="triangle">The <see cref="Triangle"/> model to validate</param>
        /// <returns><see cref="TriangleType.Error"/> if not valid, otherwise goto next calculating step</returns>
        public override TriangleType HandleRequest(Models.Triangle triangle)
        {
            // sides should have positive values
            if (triangle.A <= 0 || triangle.B <= 0 || triangle.C <= 0)
            {
                // Logger.LogError(new TriangleHandlerException("sides should have positive values"))
                return TriangleType.Error;
            }

            // summ of two sides should be more that last side
            if ((long)triangle.A + triangle.B <= triangle.C ||
                (long)triangle.A + triangle.C <= triangle.B ||
                (long)triangle.B + triangle.C <= triangle.A)
            {
                // Logger.LogError(new TriangleHandlerException("summ of two sides should be more that last side"))
                return TriangleType.Error;
            }

            if (successor?.HandleRequest(triangle) != null)
            {
                return successor.HandleRequest(triangle);
            }

            // Logger.LogError(new TriangleHandlerException("Unexpected error"))
            return TriangleType.Error;
        }
    }
}