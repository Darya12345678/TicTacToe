using System;

namespace TicTacToe
{
    class Game
    {
        private char[,] board;
        private char currentPlayer;
        private bool isGameFinished;

        public void Start()
        {
            InitializeBoard();
            currentPlayer = 'X';
            isGameFinished = false;

            while (!isGameFinished)
            {
                PrintBoard();
                MakeMove();
                CheckGameResult();
                SwitchPlayers();
            }
        }

        private void InitializeBoard()
        {
            board = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        private void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void MakeMove()
        {
            Console.WriteLine($"Игрок {currentPlayer}, сделайте свой ход (столбец строки:");
            string[] input = Console.ReadLine().Split(' ');
            int row = int.Parse(input[0]);
            int col = int.Parse(input[1]);

            if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != ' ')
            {
                Console.WriteLine("Неверный ход! Попробуйте еще раз.");
                MakeMove();
            }
            else
            {
                board[row, col] = currentPlayer;
            }
        }

        private void CheckGameResult()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                {
                    isGameFinished = true;
                    Console.WriteLine($"Игрок {currentPlayer} побеждает!");;
                    return;
                }
            }

            // Check columns
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == currentPlayer && board[1, j] == currentPlayer && board[2, j] == currentPlayer)
                {
                    isGameFinished = true;
                    Console.WriteLine($"Игрок {currentPlayer} побеждает!");
                    return;
                }
            }

            // Check diagonals
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                isGameFinished = true;
                Console.WriteLine($"Игрок {currentPlayer} побеждает!");
                return;
            }

            // Check for a draw
            bool isBoardFull = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        isBoardFull = false;
                        break;
                    }
                }
            }

            if (isBoardFull)
            {
                isGameFinished = true;
                Console.WriteLine("Ничья");
            }
        }

        private void SwitchPlayers()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }
}