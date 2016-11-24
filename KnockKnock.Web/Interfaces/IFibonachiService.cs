using System;

namespace KnockKnock.Web.Interfaces
{
    /// <summary>
    /// The interface for calculate a Fibonacci secience and get number by index
    /// </summary>
    public interface IFibonachiService
    {
        /// <summary>
        /// Returns the nth number in the fibonacci sequence.
        /// </summary>
        /// <remarks>
        /// This will be using <b>Binet formula</b>, you can use negatives and positives numbers. 
        /// You can't use <see cref="index"/> more or less that 92, this is limitations for Int64
        /// </remarks>
        /// <param name="index">
        /// The index (n) of the fibonacci sequence
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Value cannot be greater than 92 for Int64. The error is logged on the server.
        /// </exception>
        /// <returns>Fibonacci number as long</returns>
        long GetNumber(long index);
    }
}