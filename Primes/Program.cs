using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make jiter initialize all necessary method calls
            // (Warm it up)
            BasicPrimeFinder.GetPrimes(2, 1000);
            OptimizedPrimeFinder.GetPrimes(2, 1000);

            int start = 2;
            int baseValue = 2;
            int maxPower = 18;
            Stopwatch sw = new Stopwatch();

            for (int power = 1; power <= maxPower; power++)
            {
                int end = Convert.ToInt32(Math.Pow(baseValue, power));
                Console.WriteLine("Calculating primes between {0} and {1} = 2^{2}", start.ToString("N0"), end.ToString("N0"), power.ToString("N0"));

                sw.Start();

                IEnumerable<int> basicFinderResult = BasicPrimeFinder.GetPrimes(start, end);

                sw.Stop();
                long basicRunEllapsedTicks = sw.ElapsedTicks;
                Console.WriteLine("Basic Finder took {0} ticks ({1} s) to find {2} primes.", 
                    basicRunEllapsedTicks.ToString("N0"), 
                    (sw.ElapsedMilliseconds / 100).ToString("N0"),
                    basicFinderResult.Count().ToString("N0"));

                sw.Restart();

                IEnumerable<int> optimizedFinderResult = OptimizedPrimeFinder.GetPrimes(start, end);

                sw.Stop();
                long optimizedRunEllapsedTicks = sw.ElapsedTicks;
                Console.WriteLine("Optimzed Finder took {0} ticks ({1} s) to find {2} primes.", 
                    optimizedRunEllapsedTicks.ToString("N0"),
                    (sw.ElapsedMilliseconds / 100).ToString("N0"),
                    optimizedFinderResult.Count().ToString("N0"));

                string winner;
                long factor;
                if (optimizedRunEllapsedTicks < basicRunEllapsedTicks)
                {
                    winner = "Optimzed";
                    factor = basicRunEllapsedTicks / optimizedRunEllapsedTicks;
                }
                else
                {
                    winner = "Basic";
                    factor = optimizedRunEllapsedTicks / basicRunEllapsedTicks;
                }

                Console.WriteLine("Winner: {0}, by a factor of {1}", winner, factor.ToString("N2"));

                Console.WriteLine("====================================================================");
                Console.WriteLine("====================================================================");
            }

            Console.WriteLine("Hit any key to close");
            Console.ReadKey();
        }
    }
}