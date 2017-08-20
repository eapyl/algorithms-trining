using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace dijkstra
{
    class Program
    {
        public class Node
        {
            public string Name { get; set; } = string.Empty;
            public bool Visited { get; set; } = false;
            public List<Link> Links { get; set; } = new List<Link>();
            public int Distance { get; set; } = 0;
        }

        public class Link
        {
            public int Cost { get; set; } = 0;
            public Node From { get; set; } = null;
            public Node To { get; set; } = null;
        }
        static void Main(string[] args)
        {
            var A = new Node { Name = "A" };
            var B = new Node { Name = "B" };
            var C = new Node { Name = "C" };
            var D = new Node { Name = "D" };
            var E = new Node { Name = "E" };
            var F = new Node { Name = "F" };
            var G = new Node { Name = "G" };
            var H = new Node { Name = "H" };

            var l1 = new Link { Cost = 9, From = A, To = B };
            var l2 = new Link { Cost = 10, From = A, To = D };
            var l3 = new Link { Cost = 15, From = A, To = E };
            var l4 = new Link { Cost = 10, From = B, To = C };
            var l5 = new Link { Cost = 11, From = C, To = F };
            var l6 = new Link { Cost = 11, From = E, To = F };
            var l7 = new Link { Cost = 10, From = D, To = E };
            var l8 = new Link { Cost = 12, From = D, To = G };
            var l9 = new Link { Cost = 12, From = G, To = H };
            var l10 = new Link { Cost = 13, From = H, To = F };

            A.Links.Add(l1);
            A.Links.Add(l2);
            A.Links.Add(l3);
            B.Links.Add(l1);
            B.Links.Add(l4);
            C.Links.Add(l5);
            C.Links.Add(l4);
            D.Links.Add(l2);
            D.Links.Add(l7);
            D.Links.Add(l8);
            E.Links.Add(l3);
            E.Links.Add(l6);
            E.Links.Add(l7);
            F.Links.Add(l5);
            F.Links.Add(l6);
            F.Links.Add(l10);
            G.Links.Add(l8);
            G.Links.Add(l9);
            H.Links.Add(l9);
            H.Links.Add(l10);
            var watch = Stopwatch.StartNew();
            dijkstra(A);
            watch.Stop();
            Console.WriteLine($"Executed in {watch.ElapsedMilliseconds}");

            Console.WriteLine($"Dist to H - {H.Distance}");
            Console.WriteLine($"Dist to F - {F.Distance}");;
        }

        private static void dijkstra(Node startPoint)
        {
            var links = new Stack<Link>();
            startPoint.Visited = true;
            foreach (var link in startPoint.Links)
                links.Push(link);
            while (links.Count > 0)
            {
                var temp = links.Pop();
                var newDistance = temp.From.Distance + temp.Cost;
                if (temp.To.Distance == 0 || temp.To.Distance > newDistance)
                    temp.To.Distance = newDistance;
                foreach(var link in temp.To.Links.Where(x=>x.From.Name == temp.To.Name))
                    links.Push(link);
            }
        }
    }
}
