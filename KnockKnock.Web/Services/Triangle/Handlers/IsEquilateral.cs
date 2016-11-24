using KnockKnock.Web.Services.Triangle.Models;

namespace KnockKnock.Web.Services.Triangle.Handlers
{
    /// <summary>
    /// The Triangle headler
    /// Check the triangle model to equal to <b>Equilateral</b>
    /// Rule: An equilateral triangle has all sides the same length.
    /// </summary>
    internal class IsEquilateral : TriangleHandler
    {
        /// <summary>
        /// An equilateral triangle has all sides the same length.
        /// </summary>
        /// <param name="triangle">The <see cref="Triangle"/> model to calculate</param>
        /// <returns>If is <see cref="TriangleType.Equilateral"/> return it, if not goto next calculating step</returns>
        public override TriangleType HandleRequest(Models.Triangle triangle)
        {
            // sides should have positive values
            if (triangle.A == triangle.B && triangle.A == triangle.C)
            {
                return TriangleType.Equilateral;
            }

            return successor?.HandleRequest(triangle) ?? TriangleType.Error;
        }
    }
}