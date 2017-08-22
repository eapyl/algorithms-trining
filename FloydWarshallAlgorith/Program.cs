using System;
using System.Collections.Generic;
using System.Linq;

namespace FloydWarshallAlgorith
{
    class Program
    {
        public class Node
        {
            public string Name { get; set; } = string.Empty;
            public List<Link> Links { get; set; } = new List<Link>();
        }

        public class Link
        {
            public int Cost { get; set; } = 0;
            public Node From { get; set; } = null;
            public Node To { get; set; } = null;
        }

        private static (int[,], int[,]) PrepareMatrix(List<Node> nodes)
        {
            var countOfNodes = nodes.Count;
            // show distance between two nodes
            var distance = new int[countOfNodes, countOfNodes];

            for (var i = 0; i < countOfNodes; i++)
            {
                for (var j = 0; j < countOfNodes; j++)
                {
                    if (i == j)
                        // put 0 for distance between node and itself
                        distance[i, j] = 0;
                    else if (nodes[i].Links.Any(x => x.From == nodes[j] || x.To == nodes[j]))
                        // put cost of link if nodes are connected
                        distance[i, j] = nodes[i].Links.First(x => x.From == nodes[j] || x.To == nodes[j]).Cost;
                    else
                        // put Max if there is no link between nodes
                        distance[i, j] = int.MaxValue;
                }
            }

            // show via which node is closest path between two nodes
            var via = new int[countOfNodes, countOfNodes];
            for (var i = 0; i < countOfNodes; i++)
            {
                for (var j = 0; j < countOfNodes; j++)
                {
                    if (distance[i, j] < int.MaxValue)
                        via[i, j] = j;
                    else
                        via[i, j] = -1;
                }
            }

            for (var via_node = 0; via_node < countOfNodes; via_node++)
            {
                for (var from_node = 0; from_node < countOfNodes; from_node++)
                {
                    for (var to_node = 0; to_node < countOfNodes; to_node++)
                    {
                        if (distance[from_node, via_node] != int.MaxValue &&
                            distance[via_node, to_node] != int.MaxValue)
                        {
                            var new_distance = distance[from_node, via_node] + distance[via_node, to_node];
                            if (new_distance < distance[from_node, to_node])
                            {
                                distance[from_node, to_node] = new_distance;
                                via[from_node, to_node] = via_node;
                            }
                        }
                    }
                }
            }

            return (distance, via);
        }

        private static string FindPath(List<Node> nodes, int start, int end, int[,] distance, int[,] via)
        {
            if (distance[start, end] == int.MaxValue)
                return string.Empty;
            
            var via_node = via[start, end];
            if (via_node == end)
                return nodes[end].Name;
            else
                return FindPath(nodes, start, via_node, distance, via)+ "-" +
                    FindPath(nodes, via_node, end, distance, via);
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

            var list = new List<Node> { A, B, C, D, E, F, G, H };

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

            var result = PrepareMatrix(list);
            
            var path = FindPath(list, 0, 5, result.Item1, result.Item2);
            Console.WriteLine(path);
        }
    }
}
