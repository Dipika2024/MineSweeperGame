using MineSweeperGame.Models;

namespace MineSweeperGame.Repositories
{
    public interface IBoardRepository
    {
        void InitializeBoard(Board board);
        void ShowBoard(Player player, Board board);
        void SetMines(Board board, int mineCount);
        Boolean IsMine(Board board, int row, int column);
        string GetChessNotation(int row, int column);

    }
}
