using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimalSpanningTree
{
    class Program
    {
        public class Node
        {
            public string Name { get; set; } = string.Empty;
            public bool Visited { get; set; } = false;
            public List<Link> Links { get; set; } = new List<Link>();
        }

        public class Link
        {
            public int Cost { get; set; } = 0;
            public bool SpanningTreeLink { get; set; } = false;
            public Node From { get; set; } = null;
            public Node To { get; set; } = null;
        }

        public static Node FindMinimalSpanningTree(Node root)
        {
            var visitedNodes = new List<Node>();
            visitedNodes.Add(root);

            Link link;
            while ((link = FindShortedLink(visitedNodes)) != null)
            {
                link.To.Visited = true;
                link.SpanningTreeLink = true;
                visitedNodes.Add(link.To);
            }

            return root;
        }


        private static Link FindShortedLink(List<Node> nodes)
        {
            Link result = null;
            foreach (var node in nodes)
            {
                foreach (var link in node.Links.Where(x => x.To.Visited == false))
                {
                    if (result == null || result.Cost > link.Cost)
                        result = link;
                }
            }
            return result;
        }

        private static IEnumerable<Link> VisitSpanningTree(Node root)
        {
            foreach (var link in root.Links.Where(x=>x.SpanningTreeLink && x.From.Name == root.Name))
            {
                yield return link;
                foreach (var subLink in VisitSpanningTree(link.To))
                    yield return subLink;
            }
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

            var spanningTree = FindMinimalSpanningTree(A);

            foreach (var link in VisitSpanningTree(spanningTree))
            {
                Console.WriteLine($"{link.From.Name}-{link.Cost}-{link.To.Name};");
            }
        }
    }


}
