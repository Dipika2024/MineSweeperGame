using MineSweeperGame.Models;

namespace MineSweeperGame.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        public string GetChessNotation(int row, int column)
        {
            char letter = (char)('A' + column); 
            int rank = 8 - row; 
            return $"{letter}{rank}";
        }

        public void InitializeBoard(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                for (int column = 0; column < board.Columns; column++)
                {
                    board.Grid[row, column] = '.';
                }
            }
        }

        public bool IsMine(Board board, int row, int column)
        {
            return board.Grid[row, column] == '*';
        }

        public void SetMines(Board board, int mineCount)
        {
            Random _randomNumber = new Random();
            for (int i = 0; i < mineCount; i++)
            {
                int randRow = _randomNumber.Next(board.Rows);
                int randColumn = _randomNumber.Next(board.Columns);

                if (board.Grid[randRow, randColumn] != '*' || (randRow != 0 && randColumn != 0))
                {
                    board.Grid[randRow, randColumn] = '*';
                }
            }
        }

        public void ShowBoard(Player player, Board board)
        {
            Console.Clear();
            Console.WriteLine("Board:");
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (i == player.Row && j == player.Column)
                    {
                        Console.Write('P' + " ");
                    }
                    else
                    {
                        Console.Write(board.Grid[i, j] + " ");
                    }
                } 
                Console.WriteLine();
            }
            Console.WriteLine("Lives: " + player.Lives + " Moves: " + player.Moves); 
            Console.WriteLine("Current Position: " + GetChessNotation(player.Row, player.Column));
        }
     }
}
