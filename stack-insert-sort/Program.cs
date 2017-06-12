using System;
using System.Collections.Generic;

namespace stack_insert_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = StackInsertSort(new Stack<int>(new List<int> { 5, 4, 3, 2, 1 }));
            while (st.Count > 0)
                Console.WriteLine(st.Pop());
        }

        static Stack<int> StackInsertSort(Stack<int> stack)
        {
            var tempStack = new Stack<int>();
            while (stack.Count > 0)
            {
                var nextItem = stack.Pop();
                while (tempStack.Count > 0 && tempStack.Peek() < nextItem)
                {
                    stack.Push(tempStack.Pop());
                }
                tempStack.Push(nextItem);
            }
            while (tempStack.Count > 0)
                stack.Push(tempStack.Pop());
            return stack;
        }
    }
}
