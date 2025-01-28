namespace MineSweeperGame.Models
{
    public class Board
    {
        public char[,] Grid;
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new char[Rows, Columns];
        }

    }
}
