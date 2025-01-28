using MineSweeperGame.Models;

namespace MineSweeperGame.Repositories
{
    public interface IPlayerRepository
    {
        bool Move(string? direction, Board board, Player player);
    }
}
