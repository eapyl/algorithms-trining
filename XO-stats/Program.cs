using System;

namespace XO_stats
{
    class Program
    {
        static void Main(string[] args)
        {
            var stats = new int[3];
            var board = new int[3, 3] {
                {-1, -1, -1 } ,
                {-1, -1, -1 } ,
                {-1, -1, -1 }
            };

            DoGame(board, stats, 0);

            Console.WriteLine($"O wins {stats[0]}, X wins {stats[1]}, None wins {stats[2]}");
            Console.WriteLine($"Variants {stats[0] + stats[1] + stats[2]}");
        }

        private static void DoGame(int[,] board, int[] stats, int whoStart)
        {
            var status = CheckStatus(board);
            if (status > -1)
            {
                stats[status]++;
                return;
            }
            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    if (board[i, j] == -1)
                    {
                        board[i, j] = whoStart;
                        DoGame(board, stats, whoStart == 0 ? 1 : 0);
                        board[i, j] = -1;
                    }
        }

        private static int CheckStatus(int[,] board)
        {
            if (board[0, 0] != -1 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return board[1, 1];
            if (board[2, 0] != -1 && board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2])
                return board[1, 1];

            if (board[0, 0] != -1 && board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0])
                return board[1, 0];
            if (board[0, 1] != -1 && board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1])
                return board[1, 1];
            if (board[0, 2] != -1 && board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2])
                return board[1, 2];

            if (board[0, 0] != -1 && board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
                return board[0, 1];
            if (board[1, 0] != -1 && board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
                return board[1, 1];
            if (board[2, 0] != -1 && board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2])
                return board[2, 1];

            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    if (board[i, j] == -1)
                        return -1;

            return 2;
        }
    }
}
