using System;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            var desk = new int[8, 8];
            EightQueens(desk, 0);
            for(var x =0; x <8; x++)
            {
                Console.WriteLine();
                for (var y=0; y <8; y++)
                    Console.Write(desk[x,y]);
            }
            Console.WriteLine();
        }

        static bool EightQueens(int[,] desk, int numberOfQueensOnDesk)
        {
            if (!IsOk(desk)) return false;

            if (numberOfQueensOnDesk == 8) return true;
            
            for(var x =0; x <8; x++)
                for (var y=0; y <8; y++)
                    if (desk[x,y] == 0)
                    {
                        desk[x,y] = 1;
                        if (EightQueens(desk, numberOfQueensOnDesk+1))
                            return true;
                        desk[x,y] = 0;
                    }
            return false;
        }

        static bool IsOk(int[,] desk)
        {
            for(var x =0; x <8; x++)
                for (var y=0; y <8; y++)
                {
                    if (desk[x,y] == 1)
                    {
                        for (var k=0; k < 8; k++)
                        {
                            if (desk[k,y] == 1 && k!=x)  return false;
                            if (desk[x,k] == 1 && k!=y)  return false;
                        }
                        var tempX = x;
                        var tempY = y;
                        while (tempX > -1 && tempX < 8 && tempY > -1 && tempY < 8)
                        {
                            if (desk[tempX, tempY] == 1 && tempX != x && tempY != y) return false;
                            tempX--;
                            tempY--;
                        }
                        tempX = x;
                        tempY = y;
                        while (tempX > -1 && tempX < 8 && tempY > -1 && tempY < 8)
                        {
                            if (desk[tempX, tempY] == 1 && tempX != x && tempY != y) return false;
                            tempX++;
                            tempY--;
                        }
                        tempX = x;
                        tempY = y;
                        while (tempX > -1 && tempX < 8 && tempY > -1 && tempY < 8)
                        {
                            if (desk[tempX, tempY] == 1 && tempX != x && tempY != y) return false;
                            tempX--;
                            tempY++;
                        }
                        tempX = x;
                        tempY = y;
                        while (tempX > -1 && tempX < 8 && tempY > -1 && tempY < 8)
                        {
                            if (desk[tempX, tempY] == 1 && tempX != x && tempY != y) return false;
                            tempX++;
                            tempY++;
                        }
                    }
                }
            return true;
        }
    }
}
