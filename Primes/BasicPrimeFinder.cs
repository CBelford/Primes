using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    internal static class BasicPrimeFinder
    {
        // Finds primes between start and end values by brute force calculation.
        // 2 is always prime, and for every integer greater than 2, check if 
        // any integer less than the one you're inspecting can divide the one
        // you are inspecting (by checking if modulo is 0)
        // NOTE:  In good code, we'd check the arguments which are passed to make
        // sure they are appropriate.
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
