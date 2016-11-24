using KnockKnock.Web.Interfaces;
using KnockKnock.Web.Services.Triangle.Handlers;
using KnockKnock.Web.Services.Triangle.Models;

namespace KnockKnock.Web.Services.Triangle
{
    /// <summary>
    /// The triangle service for return the type of triange given the lengths of its sides.
    /// For calculate the type of triangle used <b>Chain of responsibility</b> pattern <seealso cref="https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern"/>
    /// Writed from: <see cref="https://en.wikipedia.org/wiki/Triangle#Similarity_and_congruence"/>
    /// Possible types: <see cref="TriangleType"/>
    /// </summary>
    public class TriangleService : ServiceBase, ITriangleService
    {
        private readonly IsValid _isValidHandler = new IsValid();
        private readonly IsEquilateral _isEquilateralHandler = new IsEquilateral();
        private readonly IsIsosceles _isIsoscelesHandler = new IsIsosceles();
        private readonly IsScalene _isScaleneHandler = new IsScalene();

        public TriangleService()
        {
            _isValidHandler.SetSuccessor(_isEquilateralHandler);
            _isEquilateralHandler.SetSuccessor(_isIsoscelesHandler);
            _isIsoscelesHandler.SetSuccessor(_isScaleneHandler);
        }

        /// <summary>
        /// The implimentation for calculate the triangle type
        /// </summary>
        /// <param name="triangle"><see cref="Triangle"/> model to calculate</param>
        /// <returns>The type of triangle: <see cref="TriangleType"/></returns>
        public TriangleType GetTriangleType(Models.Triangle triangle)
        {
            var result = GetFromCache<TriangleType>(triangle.ToString());
            if (result != TriangleType.Error)
            {
                return result;
            }

            result = _isValidHandler.HandleRequest(triangle);
            AddToCache(result);
            return result;
        }
    }
}