using MineSweeperGame.Models;
using MineSweeperGame.Repositories;

namespace MineSweeperGame.Services
{
    internal class GameService
    {
        private Player _player;
        private Board _board;
        private IBoardRepository _boardRepository;
        private IPlayerRepository _playerRepository;

        public GameService()
        {
            _board = new Board(8, 8);
            _player = new Player();
            _boardRepository = new BoardRepository();
            _playerRepository = new PlayerRepository();
        }

        public void StartGame()
        {
            _boardRepository.InitializeBoard(_board);
            _boardRepository.SetMines(_board, 10);
            _boardRepository.ShowBoard(_player, _board);

            while (_player.Lives > 0 && _player.Row < _board.Rows - 1 && _player.Column < _board.Columns - 1)
            {
                Console.Write("Enter move (up, down, left, right): ");

                string? move = Console.ReadLine();

                if (!_playerRepository.Move(move?.ToLower(), _board, _player))
                {
                    continue;
                }
                _player.Moves++;
                bool isMine = _boardRepository.IsMine(_board, _player.Row, _player.Column);
                if (isMine)
                {
                    _player.Lives--;
                }
                _boardRepository.ShowBoard(_player, _board);
                if (isMine)
                {
                    Console.WriteLine("Boom! You hit a mine. Lives remaining: " + _player.Lives);
                }

            }

            if (_player.Lives > 0)
            {
                Console.WriteLine("Congratulations! You have reached the other side in " + _player.Moves + " moves.");
                Console.WriteLine("Your Final Score is :" + _player.Moves + ".");

            }
            else
            {
                Console.WriteLine("Game Over! You ran out of lives.");
            }
            Console.ReadLine();
        }
    }
}
