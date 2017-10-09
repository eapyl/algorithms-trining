using System;
using System.Collections.Generic;
using System.Linq;

namespace find_factors
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var factor in FindFactors(344))
                Console.WriteLine(factor);
        }

        static IEnumerable<int> FindFactors(int number)
        {
            while (number % 2 == 0)
            {
                yield return 2;
                number /= 2;
            }
            var i = 3;
            var maxFactor = Math.Sqrt(number);
            while (i <= maxFactor)
            {
                while (number % i == 0)
                {
                    yield return i;
                    number /= i;
                    maxFactor = Math.Sqrt(number);
                }
                i += 2;
            }
            if (number > 1) yield return number;
        }
    }
}
