using System;

namespace turtle_and_rabbit
{
    class Program
    {
        static void Main(string[] args)
        {
            var H = new Cell { Value = "H", Next = null};
            var G = new Cell { Value = "G", Next = H};
            var F = new Cell { Value = "F", Next = G};
            var E = new Cell { Value = "E", Next = F};
            var D = new Cell { Value = "D", Next = E};
            H.Next = D;
            var C = new Cell { Value = "C", Next = D};
            var B = new Cell { Value = "B", Next = C};
            var A = new Cell { Value = "A", Next = B};
            Console.WriteLine(BeginOfCircle(A));
        }

        static string BeginOfCircle(Cell root)
        {
            var turtle = root;
            var rabbit = root;
            Func<Cell, Cell> rabbitStep = (cell) => cell.Next.Next;
            bool secondPhase = false;
            var i = 1;
            while (true)
            {
                Console.WriteLine(i + "Turtle " + turtle.Value);
                Console.WriteLine(i + "Rabbit " + rabbit.Value);
                if (rabbit == null || rabbit.Next == null) return string.Empty;
                turtle = turtle.Next;
                rabbit = rabbitStep(rabbit);
                if (turtle.Value == rabbit.Value)
                {
                    if (secondPhase == true)
                    {
                        return turtle.Value;
                    }
                    Console.WriteLine("Start second phase: rabbit step is 1");
                    rabbit = root;
                    rabbitStep = (cell) => cell.Next;
                    secondPhase = true;
                }
                i++;
            }
        }

        class Cell
        {
            public string Value { get; set; }
            public Cell Next { get; set; }
        }
    }
}
