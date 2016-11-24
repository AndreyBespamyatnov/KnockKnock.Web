using KnockKnock.Web.Services.Triangle.Models;

namespace KnockKnock.Web.Interfaces
{
    /// <summary>
    /// The triangle service for return the type of triange given the lengths of its sides.
    /// For calculate the type of triangle used <b>Chain of responsibility</b> pattern <seealso cref="https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern"/>
    /// Writed from: <see cref="https://en.wikipedia.org/wiki/Triangle#Similarity_and_congruence"/>
    /// Possible types: <see cref="TriangleType"/>
    /// </summary>
    public interface ITriangleService
    {
        /// <summary>
        /// The implimentation for calculate the triangle type
        /// </summary>
        /// <param name="triangle"><see cref="Triangle"/> model to calculate</param>
        /// <returns>The type of triangle: <see cref="TriangleType"/></returns>
        TriangleType GetTriangleType(Services.Triangle.Models.Triangle triangle);
    }
}