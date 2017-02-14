using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    internal static class OptimizedPrimeFinder
    {
        // Calculates primes between the start and end values using some math tricks
        // NOTE:  In good code, we'd check the arguments which are passed to make
        // sure they are appropriate.
        public static IEnumerable<int> GetPrimes(int start, int end)
        {
            // Set up the integers to test
            IEnumerable<int> integers = Enumerable.Range(start, end - start + 1);

            // Set up a dictionary of results
            Dictionary<int, bool?> intIsPrime = new Dictionary<int, bool?>();
            foreach (var integer in integers)
            {
                intIsPrime.Add(integer, null);
            }

            // Use the Sieve of Erasthenese to strike out integers you don't need to check
            // Multiplication is faster than division, so when you find a prime, multiply 
            // it by every other number you have, and flag those as not prime.  (Why? Because
            // you just constructed it to be divisible by a prime)
            foreach (var integer in integers)
            {
                // If we haven't checked it yet
                if (!intIsPrime[integer].HasValue)
                {
                    // See if it is prime
                    bool isPrime = IsPrime(integer);
                    if (isPrime)
                    {
                        // Flag it as prime
                        intIsPrime[integer] = true;

                        // Multiple the prime by all your other integers, but don't go too far,
                        // you're not looking for primes beyond your "end" value
                        int valueToSkip;
                        for (int value = 2; (valueToSkip = value * integer) <= end; value++)
                        {
                            intIsPrime[valueToSkip] = false;
                        }
                    }
                }
            }

            return intIsPrime.Where(kvp => (kvp.Value == true)).Select(kvp => kvp.Key);
        }

        private static bool IsPrime(int integer)
        {
            // A basic math theorm says that you don't have to check if all integers
            // less than the integer in question can divide it, you only have to check
            // if integers less than (or equal) the square root of the integer in question
            // can divide it.
            bool isCompond = false;
            for (int current = 2; current <= Math.Sqrt(integer); current++)
            {
                isCompond = (integer % current == 0);
                if (isCompond)
                {
                    break;
                }
            }
            return !isCompond;
        }
    }
}
