using System;

namespace PracticeSupport
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.DisplayBoard();
            Console.WriteLine();

            Random rand = new Random();
            bool isGameOver = false;
            int rotation = 0;
            while (!isGameOver)
            {
                board.InsertCoin(rotation%2 +1, rand.Next(0,6));
                board.DisplayBoard();
                isGameOver = board.IsWinner(rotation % 2 + 1);
                if (isGameOver)
                {
                    Console.WriteLine("{0} won the game ", rotation % 2 + 1);
                }
                rotation++;
            }
        }

    }

    class Board
    {
        public int rows = 6, cols = 7, player1 = 1, player2 = 2;
        int[,] board;

        public Board()
        {
            this.board = new int[rows, cols];
        }

        public void DisplayBoard()
        {
            for (int i = rows-1; i >= 0; i--)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool IsWinner(int player)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols - 3; j++)
                {
                    if(board[i,j] == player && board[i, j+1] == player && board[i, j+2] == player && board[i, j+3] == player)
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i < rows -3; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == player && board[i+1, j] == player && board[i+2, j] == player && board[i+3, j] == player)
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < rows - 3; i++)
            {
                for (int j = 0; j < cols -3; j++)
                {
                    if (board[i, j] == player && board[i + 1, j +1] == player && board[i + 2, j+2] == player && board[i+3, j+3] == player)
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < rows - 3; i++)
            {
                for (int j = 3; j < cols; j++)
                {
                    if (board[i, j] == player && board[i + 1, j - 1] == player && board[i + 2, j - 2] == player && board[i + 3, j - 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void InsertCoin(int player, int col)
        {
            for (int i = 0; i < rows; i++)
            {
                if (board[i, col] != 0) {
                    continue;
                }
                board[i, col] = player;
                break;
            }
        }

    }
}
