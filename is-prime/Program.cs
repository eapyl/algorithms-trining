using System;

namespace is_prime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPrime(43, 3));
        }

        static bool IsPrime(int p, int tries)
        {
            for (var i =0; i < tries; i++)
            {
                var n = i+2;
                if (n >= p) break;
                if (Math.Pow(n, p - 1) % p != 1) return false;
            }
            // it is prime number with probability = 1/ (2^tries)
            return true;
        }
    }
}
