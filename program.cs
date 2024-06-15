using System;

class TicTacToe
{
    private char[,] board;
    private char currentPlayer;

    public TicTacToe()
    {
        board = new char[3, 3];
        currentPlayer = 'X';
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = '-';
            }
        }
    }

    public void PrintBoard()
    {
        Console.WriteLine("  0 1 2");
        for (int row = 0; row < 3; row++)
        {
            Console.Write(row + " ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    public bool MakeMove(int row, int col)
    {
        if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != '-')
        {
            return false;
        }

        board[row, col] = currentPlayer;
        return true;
    }

    public bool CheckForWin()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
            {
                return true;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
            {
                return true;
            }
        }

        // Check diagonals
        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {
            return true;
        }

        return false;
    }

    public bool IsBoardFull()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == '-')
                {
                    return false;
                }
            }
        }
        return true;
    }

    public char GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }
}

class Program
{
    static void Main(string[] args)
    {
        TicTacToe game = new TicTacToe();
        bool gameOver = false;

        Console.WriteLine("Welcome to Tic-Tac-Toe!");

        while (!gameOver)
        {
            Console.WriteLine();
            game.PrintBoard();
            Console.WriteLine("Player " + game.GetCurrentPlayer() + ", enter your move (row col):");

            string[] input = Console.ReadLine().Split();
            if (input.Length != 2 || !int.TryParse(input[0], out int row) || !int.TryParse(input[1], out int col))
            {
                Console.WriteLine("Invalid input. Please enter two numbers separated by a space.");
                continue;
            }

            if (!game.MakeMove(row, col))
            {
                Console.WriteLine("Invalid move. Please try again.");
                continue;
            }

            if (game.CheckForWin())
            {
                Console.WriteLine("Player " + game.GetCurrentPlayer() + " wins!");
                gameOver = true;
            }
            else if (game.IsBoardFull())
            {
                Console.WriteLine("It's a draw!");
                gameOver = true;
            }
            else
            {
                game.SwitchPlayer();
            }
        }
    }
}
