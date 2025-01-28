using MineSweeperGame.Models;

namespace MineSweeperGame.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public bool Move(string? direction, Board board, Player player)
        {
            switch (direction) 
            { 
                case "up":
                    if (player.Row > 0) {player.Row--;}
                    else
                    {
                        Console.WriteLine("Invalid move. Try again.");
                        return false;
                    } 
                    break; 
                case "down": 
                    if (player.Row < board.Rows - 1) player.Row++;
                    break; 
                case "left":
                    if (player.Column > 0) { player.Column--; }
                    else
                    {
                        Console.WriteLine("Invalid move. Try again.");
                        return false;
                    }
                    break; 
                case "right": 
                    if (player.Column < board.Columns - 1) player.Column++;
                    break; 
                default: Console.WriteLine("Invalid move. Try again.");
                    return false;
            }
            return true;
        }
    }
}
