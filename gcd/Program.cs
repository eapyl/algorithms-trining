using System;
using System.Diagnostics;

namespace gcd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GCD(24, 24));
        }

        static int GCD(int a, int b)
        {
            Debug.Assert(a > b, $"{nameof(a)} should be bigger than {nameof(b)}");
            int remainder = 0;
            while (b != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }
    }
}
