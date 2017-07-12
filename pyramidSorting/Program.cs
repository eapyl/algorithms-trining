using System;

namespace pyramidSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[]{4,6,2,7,1,5};
            Heapsort(array);
            Console.WriteLine(string.Join(",", array));
        }

        private static void MakeHeap(int[] values)
        {
            //start adding one by one to a heap
            for (var i=0; i < values.Length; i++)
            {
                //start
                var index = i;
                while(index != 0)
                {
                    // index of a parent
                    var parent = (index - 1)/2;

                    // stop if parent is bigger than child
                    if (values[index] <= values[parent]) break;

                    // change parent and child
                    var temp = values[index];
                    values[index] = values[parent];
                    values[parent] = temp;

                    //go to parent
                    index = parent;
                }
            }
        }

        private static int RemoveTopItem(int[] values, int count)
        {
            // move biggest to the end
            var result = values[0];
            values[0] = values[count - 1];
            var index = 0;
            while (true)
            {
                //children
                var child1 = 2*index +1;
                var child2 = 2*index + 2;
                if (child1 >= count)
                    child1 = index;
                if (child2 >= count)
                    child2 = index;

                // it is a heap
                if (values[index]>=values[child1] && values[index]>= values[child2]) break;

                // index of the biggest child
                var swap_child = values[child1] > values[child2] ? child1 : child2;

                //swap with the biggest child
                var temp = values[index];
                values[index] = values[swap_child];
                values[swap_child] = temp;

                index = swap_child;
            }

            return result;
        }

        private static void Heapsort(int[] values)
        {
            MakeHeap(values);
            for (var i = values.Length; i >0; i--)
            {
                //put biggest element to the end of the array
                values[i-1] = RemoveTopItem(values, i);
            }
        }
    }
}
