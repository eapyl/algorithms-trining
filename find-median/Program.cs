using System;
using System.Linq;

namespace find_median
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindMedian(new[]{1, 4, 3, 5}));

        }

        static double FindMedian(int[] arr)
        {
            if (arr.Length == 0) return 0;
            Array.Sort(arr);
            return arr.Length % 2 == 0 ? (arr[arr.Length/2-1] + arr[arr.Length/2])/2.0 : arr[arr.Length/2];
        }
    }
}
