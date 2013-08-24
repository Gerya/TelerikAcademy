using BaloonsPop.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using BaloonsPop.Client;

namespace BaloonsPop.Tests
{
    [TestClass]
    public class GameBoardManagerTest
    {
        private readonly GameBoardManager testBoard = new GameBoardManager();

        //testing for gameboard if it is full with ballons balloons
        [TestMethod]
        public void TestMethod1GenerateNewGameBoardTest()
        {
            testBoard.GenerateNewGameBoard();
            bool isBaloon = true;
            for (int col = 4; col < 10; col++)
            {
                for (int row = 2; row < 5; row++)
                {
                    if ((testBoard.GameBoard[col, row] < '1') && (testBoard.GameBoard[col, row] > '4'))
                    {
                        isBaloon = false;
                    }
                    else
                    {
                        isBaloon = true;
                    }
                }
            }
            Assert.IsTrue(isBaloon);
        }

        [TestMethod]
        public void TestIsGoodBoard()
        {
            testBoard.GenerateNewGameBoard();
            bool isGoodLeftTopCornerBoard = false;
            bool isGoodRightTopCornerBoard = false;
            bool isGoodLeftBottomCornerBoard = false;
            bool isGoodRightBottomCornerBoard = false;
            bool isGoodBoard = false;
            if (testBoard.GameBoard[2,2] == '|')
            {
                isGoodLeftTopCornerBoard = true;
            }
            if (testBoard.GameBoard[2, 6] == '|')
            {
                isGoodLeftBottomCornerBoard = true;
            }
            if (testBoard.GameBoard[24, 2] == '|')
            {
                isGoodRightTopCornerBoard = true;
            }
            if (testBoard.GameBoard[24, 6] == '|')
            {
                isGoodRightBottomCornerBoard = true;
            }
            if (isGoodLeftTopCornerBoard && isGoodLeftBottomCornerBoard && isGoodRightTopCornerBoard && isGoodRightBottomCornerBoard) 
            {
                isGoodBoard = true;
            }
            Assert.IsTrue(isGoodBoard);
        }

        [TestMethod]
        public void ShootBaloons_CoordinatesFourFour()
        {
            GameBoardManager gameBoardManager = new GameBoardManager();
            gameBoardManager.GenerateNewGameBoard();
            string input = "4 4";
            Coordinates coordinates = new Coordinates();
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
            char arr = gameBoardManager.GameBoard[12, 2];
            char result = '.';
            Assert.AreEqual(result, arr);
        }

        [TestMethod]
        public void ShootBaloons_CoordinatesZeroZero()
        {
            GameBoardManager gameBoardManager = new GameBoardManager();
            gameBoardManager.GenerateNewGameBoard();
            string input = "0 0";
            Coordinates coordinates = new Coordinates();
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
            char arr = gameBoardManager.GameBoard[4, 2];
            char result = '.';
            Assert.AreEqual(result, arr);
        }

        [TestMethod]
        public void ShootBaloons_CoordinatesTwoOne()
        {
            GameBoardManager gameBoardManager = new GameBoardManager();
            gameBoardManager.GenerateNewGameBoard();
            string input = "2 1";
            Coordinates coordinates = new Coordinates();
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
            char arr = gameBoardManager.GameBoard[6, 2];
            char result = '.';
            Assert.AreEqual(result, arr);
        }

        [TestMethod]
        [ExpectedException(typeof(PopedBallonException),
         "Cannot pop missing ballon!")]
        public void ShootBaloons_HitPosition()
        {
            GameBoardManager gameBoardManager = new GameBoardManager();
            gameBoardManager.GenerateNewGameBoard();
            string input = "2 1";
            Coordinates coordinates = new Coordinates();
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
            input = "0 1";
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
        }

        [TestMethod]
        public void ShootCounter_OneShoot()
        {
            GameBoardManager gameBoardManager = new GameBoardManager();
            gameBoardManager.GenerateNewGameBoard();
            string input = "0 1";
            Coordinates coordinates = new Coordinates();
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
            Assert.AreEqual(1, gameBoardManager.ShootCounter);
        }

        [TestMethod]
        public void ShootCounter_ThreeShoots()
        {
            GameBoardManager gameBoardManager = new GameBoardManager();
            gameBoardManager.GenerateNewGameBoard();
            string input = "0 0";
            Coordinates coordinates = new Coordinates();
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
            input = "1 1";
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
            input = "2 2";
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
            Assert.AreEqual(3, gameBoardManager.ShootCounter);
        }

        [TestMethod]
        public void RemainingBaloons_OneShot()
        {
            GameBoardManager gameBoardManager = new GameBoardManager();
            gameBoardManager.GenerateNewGameBoard();
            string input = "0 0";
            Coordinates coordinates = new Coordinates();
            Coordinates.TryParse(input, ref coordinates);
            gameBoardManager.ShootBaloons(coordinates);
            Assert.IsTrue(gameBoardManager.RemainingBaloons < 50);
        }

        [TestMethod]
        public void PrintGameBoard()
        {
            GameBoardManager gameBoardManager = new GameBoardManager();
            gameBoardManager.GenerateNewGameBoard();
            StringBuilder gameBoardAsString = new StringBuilder();
            StringBuilder printed = new StringBuilder();
            StringBuilder current = new StringBuilder();
            gameBoardAsString.AppendLine();
            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 25; row++)
                {
                    gameBoardAsString.Append(gameBoardManager.GameBoard[row, col]);
                }

                gameBoardAsString.AppendLine();
            }

            Console.SetOut(new System.IO.StringWriter(printed));
            gameBoardManager.PrintGameBoard();
            Console.SetOut(new System.IO.StringWriter(current));
            Console.WriteLine(gameBoardAsString);

            Assert.AreEqual(current.ToString(), printed.ToString());
        }
    }
}