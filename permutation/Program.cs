using System;
using System.Collections.Generic;
using System.Linq;

namespace permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var i =0;
            foreach (var per in PermutateString("abcd"))
                Console.WriteLine((i++) + per);

        }

        static IEnumerable<string> PermutateString(string s)
        {
            //Console.WriteLine(s);
            if (s.Length == 1) yield return s;
            if (s.Length > 1)
            {
                var ch = s[0].ToString();
                foreach (var permutation in PermutateString(s.Substring(1)))
                {
                    for (var i = 0; i < permutation.Length+1; i++)
                        yield return permutation.Insert(i, ch);
                }
            }
        }
    }
}
