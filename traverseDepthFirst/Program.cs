using System;
using System.Collections.Generic;

namespace traverseDepthFirst
{
    class Program
    {
        class Node{
            public Node Left;
            public Node Right;

            public string Id;
        }

        static void Main(string[] args)
        {
            var root = new Node{Id = "A"};
            var child1 = new Node{Id = "B"};
            var child2 = new Node{Id = "C"};
            var child11 = new Node{Id = "D"};
            var child12 = new Node{Id = "E"};
            var child111 = new Node{Id = "F"};
            var child21 = new Node{Id = "G"};

            root.Left = child1;
            root.Right = child2;
            child1.Left= child11;
            child1.Right = child12;
            child11.Left = child111;
            child2.Left = child21;

            /*
            A   -> B    -> D    -> F
                        -> E
                -> C    -> G
             */

            TraverseDepthFirst(root);
        }

        static void TraverseDepthFirst(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.Write(node.Id+"-");
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
            
        }
    }
}
