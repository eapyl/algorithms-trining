using System;
using System.Diagnostics;

namespace numerical_integration_trapeze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IntegrationByTrapeze(x => x * x, 0, 10, 5));
        }

        static double IntegrationByTrapeze(Func<double, double> func, double xmin, double xmax, int number_intervals)
        {
            Debug.Assert(xmin < xmax);
            var widthOfTrapeze = (xmax - xmin) / number_intervals;
            var result = 0.0;
            var x = xmin;
            for (var i =0; i < number_intervals; i++)
            {
                result += widthOfTrapeze * (func(x) + func(x+widthOfTrapeze))/2;
                x += widthOfTrapeze;
            }
            return result;
        }
    }
}
