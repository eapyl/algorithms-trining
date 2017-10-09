using System;
using System.Collections.Generic;

namespace hanoitower
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new Stack<int>();
            for(var i = 3; i >0; i--)
            {
                A.Push(i);
            }
            HanoiTower((A, "A"), (new Stack<int>(), "B"), (new Stack<int>(), "C"), 3);
        }

        // move n disks from A to B 
        static void HanoiTower((Stack<int>, string) A, (Stack<int>, string) B, (Stack<int>, string) C, int n)
        {
            // move n-1 disk from A to C
            if (n > 1) 
                HanoiTower(A, C, B, n-1);
            
            // move the biggest disk from A to B (b is empty heres)
            B.Item1.Push(A.Item1.Pop());
            Console.Write($"{A.Item2}->{B.Item2};");
            // move n-1 disk from C to B
            if (n > 1)
                HanoiTower(C, B, A, n-1);

        }
    }
}
