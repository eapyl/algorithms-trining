using System;

namespace mergesort
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new int[] {4,6,2,8,5,7, 9, 1};
            Mergesort(data, new int[data.Length], 0, data.Length -1);
            foreach (var i in data)
                Console.Write(i+ " ");
        }

        private static void Mergesort(int[] values, int[] scratch, int start, int end)
        {
            if (start == end) return;
            var midpoint = (start + end) /2;
            
            Mergesort(values, scratch, start, midpoint);
            Mergesort(values, scratch, midpoint+1, end);

            var left_index = start;
            var right_index = midpoint +1;
            var scratch_index = left_index;
            while (left_index <= midpoint && right_index <= end)
            {
                if (values[left_index]<= values[right_index])
                {
                    scratch[scratch_index] = values[left_index];
                    left_index++;
                }
                else
                {
                    scratch[scratch_index]= values[right_index];
                    right_index++;
                }
                scratch_index++;
            }
            for(var i = left_index; i <= midpoint; i++)
            {
                scratch[scratch_index] = values[i];
                scratch_index++;
            }
            for (var i = right_index; i <=end; i++)
            {
                scratch[scratch_index] = values[i];
                scratch_index++;
            }

            for (var i = start; i< end+1; i++)
            {
                values[i] = scratch[i];
            }

        }
    }
}
