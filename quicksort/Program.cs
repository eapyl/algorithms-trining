using System;

namespace quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[] {4,6,2,8,5,7, 9, 1};
            Quicksort(data, 0, data.Length -1);
            foreach (var i in data)
                Console.Write(i+ " ");
        }

        private static void Quicksort(int[] values, int start, int end)
        {
            if (start >= end) return;
            var divider = values[start];

            var lo = start;
            var hi = end;
            while(true)
            {
                while(values[hi] >= divider)
                {
                    hi--;
                    if (hi <= lo) break;
                }
                if (hi <= lo)
                {
                    values[lo] = divider;
                    break;
                }

                values[lo] = values[hi];
                lo++;
                while(values[lo] < divider)
                {
                    lo++;
                    if (lo >= hi) break;
                }
                if(lo >= hi)
                {
                    lo =hi;
                    values[hi] = divider;
                    break;
                }
                values[hi] = values[lo];
            }
            Quicksort(values, start, lo -1);
            Quicksort(values, lo + 1, end);
        }
    }
}
