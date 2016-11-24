using KnockKnock.Web.Services.Triangle.Models;

namespace KnockKnock.Web.Services.Triangle.Handlers
{
    /// <summary>
    /// The abstract class for calculate the triangle type
    /// Used the <b>chain of responsibility pattern</b> <see cref="https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern"/>
    /// </summary>
    abstract class TriangleHandler
    {
        protected TriangleHandler successor;

        public void SetSuccessor(TriangleHandler successor)
        {
            this.successor = successor;
        }

        public abstract TriangleType HandleRequest(Models.Triangle triangle);
    }
}