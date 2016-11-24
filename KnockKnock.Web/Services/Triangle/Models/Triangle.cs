namespace KnockKnock.Web.Services.Triangle.Models
{
    /// <summary>
    /// The Triangle model
    /// </summary>
    public struct Triangle
    {
        public int A { get; }
        public int B { get; }
        public int C { get; }

        public Triangle(int a, int b, int c) : this()
        {
            A = a;
            B = b;
            C = c;
        }

        public override string ToString()
        {
            return $"{A}_{B}_{C}";
        }
    }
}