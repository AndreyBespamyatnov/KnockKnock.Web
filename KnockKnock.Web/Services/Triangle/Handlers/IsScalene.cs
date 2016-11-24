using KnockKnock.Web.Services.Triangle.Models;

namespace KnockKnock.Web.Services.Triangle.Handlers
{
    /// <summary>
    /// The Triangle headler
    /// Check the triangle model to equal to <b>Scalene</b>
    /// Rule: A scalene triangle has all its sides of different lengths
    /// </summary>
    internal class IsScalene : TriangleHandler
    {
        /// <summary>
        /// A scalene triangle has all its sides of different lengths.
        /// </summary>
        /// <param name="triangle">The <see cref="Triangle"/> model to calculate</param>
        /// <returns>If is <see cref="TriangleType.Scalene"/> return it, if not goto next calculating step</returns>
        public override TriangleType HandleRequest(Models.Triangle triangle)
        {
            if (triangle.A != triangle.B &&
                triangle.A != triangle.C &&
                triangle.B != triangle.C)
            {
                return TriangleType.Scalene;
            }

            return successor?.HandleRequest(triangle) ?? TriangleType.Error;
        }
    }
}