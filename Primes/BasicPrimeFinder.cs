using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    internal static class BasicPrimeFinder
    {
        public static IEnumerable<int> GetPrimes(int start, int end)
        {
            List<int> primes = new List<int>();

            if (start == 2)
            {
                primes.Add(2);
                start++;
            }

            for (int integer = start; integer <= end; integer++)
            {
                bool isCompound = false;

                for (int factor = 2; factor < integer; factor++)
                {
                    if (integer % factor == 0)
                    {
                        isCompound = true;
                        break;
                    }
                }

                if (!isCompound)
                {
                    primes.Add(integer);
                }
            }

            return primes;
        }
    }
}
