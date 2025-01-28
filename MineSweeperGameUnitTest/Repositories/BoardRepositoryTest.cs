using MineSweeperGame.Models;
using MineSweeperGame.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperGameUnitTest.Repositories
{
    public class BoardRepositoryTest
    {
        private readonly IBoardRepository _boardRepository;
        private readonly Board _board;

        public BoardRepositoryTest()
        {
            _boardRepository = new BoardRepository();
            _board = new Board(8, 8);
        }

        [Fact]
        public void GetChessNotation_ShouldGiveCorrectNotation()
        {
            //Arrange
            int row = 0;
            int column = 0;
            string result = "A8";

            
            //Act
            var output = _boardRepository.GetChessNotation(row, column);

            // Assert
            Assert.Equal(result, output);


        }

        [Fact]
        public void Initialize_ShouldSetUpBoardWithCorrectChar()
        {
            //Act
            _boardRepository.InitializeBoard(_board);

            //Assert
            for (int i = 0; i < _board.Rows; i++)
            {
                for (int j = 0; j < _board.Columns; j++)
                {
                    Assert.Equal('.', _board.Grid[i, j]);
                }
            }
        }

        [Fact]
        public void SetMines_ShouldPlaceCorrectNumberOfMine()
        {
            //Arrange
            int minesCount = 0;
            int numberOfMines = 10;

            //Act
            _boardRepository.SetMines(_board, numberOfMines);

            //Assert
            for (int i = 0; i < _board.Rows; i++)
            {
                for (int j = 0; j < _board.Columns; j++)
                {
                    if (_board.Grid[i, j] == '*')
                    {
                        minesCount++;
                    }
                }
            }
            Assert.Equal(numberOfMines, minesCount);
        }

        [Fact]
        public void IsMine_ShouldReturnTrueforMineExist()
        {
            //Arrange
            _boardRepository.InitializeBoard(_board);
            _board.Grid[0, 1] = '*';

            //Act
            var result = _boardRepository.IsMine(_board, 0, 1);

            //Assert
            Assert.True(result);
        }
    }
}
