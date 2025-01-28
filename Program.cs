using MineSweeperGame.Services;

namespace MineSweeperGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mine Sweeper Game");
            GameService service = new GameService();
            service.StartGame();
        }
    }
}