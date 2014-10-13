using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    internal static class OptimizedPrimeFinder
    {
        public static IEnumerable<int> GetPrimes(int start, int end)
        {
            Dictionary<int, bool?> intIsPrime = new Dictionary<int, bool?>();
            IEnumerable<int> integers = Enumerable.Range(start, end - start + 1);
            foreach (var integer in integers)
            {
                intIsPrime.Add(integer, null);
            }

            foreach (var integer in integers)
            {
                if (!intIsPrime[integer].HasValue)
                {
                    bool isPrime = IsPrime(integer);
                    if (isPrime)
                    {
                        intIsPrime[integer] = true;
                        int valueToSkip;
                        for (int value = 2; (valueToSkip = value * integer) <= end; value++)
                        {
                            intIsPrime[valueToSkip] = false;
                        }
                    }
                }
            }

            return intIsPrime.Where(kvp => kvp.Value == true).Select(kvp => kvp.Key);
        }

        private static bool IsPrime(int integer)
        {
            bool isCompond = false;
            for (int current = 2; current <= Math.Sqrt(integer); current++)
            {
                isCompond = (integer % current == 0);
                if (isCompond)
                    break;
            }
            return !isCompond;
        }
    }
}
