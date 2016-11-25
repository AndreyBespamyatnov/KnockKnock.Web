using System;
using KnockKnock.Web.Interfaces;

namespace KnockKnock.Web.Services.Fibanacci
{
    public class FibonachiService : ServiceBase, IFibonacciService
    {
        private const long Threshold = 92; // 92 is the maximum for long

        /// <summary>
        /// Get Fibonacci nuber by index 
        /// Used memory cache for optimization
        /// Errors logged
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The number from Fibonacci siquence by <see cref="index"/></returns>
        public long GetNumber(long index)
        {
            try
            {
                long result = GetFromCache(index);
                if (result != 0)
                {
                    return result;
                }

                result = Fibonacci(index);
                AddToCache(index);
                return result;
            }
            catch (Exception ex)
            {
                LogErrorException(ex);
                throw;
            }
        }

        /// <summary>
        /// Using algoritm from https://en.wikibooks.org/wiki/Algorithm_Implementation/Mathematics/Fibonacci_Number_Program#Binet.27s_formula
        /// Used <b>Binet's formula</b> because it for negotives and positives numbers
        /// </summary>
        /// <param name="n">Number</param>
        /// <returns>Fibonacci number</returns>
        private long Fibonacci(long n)
        {
            if (n > Threshold)
            {
                var exception = new ArgumentOutOfRangeException(nameof(n), $"Value cannot be greater than {Threshold}.");
                LogErrorException(exception);
                throw exception;
            }
            if (n < -Threshold)
            {
                var exception = new ArgumentOutOfRangeException(nameof(n), $"Value cannot be less than {-Threshold}.");
                LogErrorException(exception);
                throw exception;
            }

            var sqrt5 = Math.Sqrt(5.0);
            var phi = (1 + sqrt5) / 2;
            return (long)((Math.Pow(phi, n) - Math.Pow(-phi, -n)) / sqrt5);
        }
    }
}