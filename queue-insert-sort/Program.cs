using System;
using System.Collections.Generic;

namespace queue_insert_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queue<int>(new List<int> { 3, 5, 2, 1, 4 });
            var sorted = QueueInsertSort(q);
            while (sorted.Count > 0)
                Console.WriteLine(sorted.Dequeue());
        }

        static Queue<int> QueueInsertSort(Queue<int> queue)
        {
            for (var i = 0; i < queue.Count; i++)
            {
                var temp = new Queue<int>(queue.Count);
                for (var j = 0; j < i+1; j++)
                    temp.Enqueue(queue.Dequeue());
                for (var j = 0; j < i; j++)
                    temp.Enqueue(temp.Dequeue());
                while (queue.Count > 0)
                {
                    var item = queue.Dequeue();
                    while (temp.Count > 0 && temp.Peek() < item)
                    {
                        queue.Enqueue(temp.Dequeue());
                    }
                    temp.Enqueue(item);
                }
                queue = temp;
            }
            return queue;
        }
    }
}
