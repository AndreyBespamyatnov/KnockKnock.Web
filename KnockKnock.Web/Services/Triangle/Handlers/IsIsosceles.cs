﻿using KnockKnock.Web.Services.Triangle.Models;

namespace KnockKnock.Web.Services.Triangle.Handlers
{
    /// <summary>
    /// The Triangle headler
    /// Check the triangle model to equal to <b>Isosceles</b>
    /// Rule: An isosceles triangle has two sides of equal length.
    /// </summary>
    internal class IsIsosceles : TriangleHandler
    {
        /// <summary>
        /// An isosceles triangle has two sides of equal length.
        /// </summary>
        /// <param name="triangle">The <see cref="Triangle"/> model to calculate</param>
        /// <returns>If is <see cref="TriangleType.Isosceles"/> return it, if not goto next calculating step</returns>
        public override TriangleType HandleRequest(Models.Triangle triangle)
        {
            if (triangle.A == triangle.B || triangle.A == triangle.C || triangle.B == triangle.C)
            {
                return TriangleType.Isosceles;
            }

            return successor?.HandleRequest(triangle) ?? TriangleType.Error;
        }
    }
}