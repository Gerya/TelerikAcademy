//-----------------------------------------------------------------------
// <copyright file="GameBoardManager.cs" company="Telerik">
// Group: Zirconium
// Project: Game Balloons Pop
// Copyright (c) 2013 Telerik. All rights reserved.
//
// </copyright>
//-----------------------------------------------------------------------

namespace BaloonsPop.Client
{
    using System;
    using System.Text;

    /// <summary>
    /// Class for control and rule game board.
    /// </summary>
    public class GameBoardManager
    {
        /// <summary>
        /// Create game board.
        /// </summary>
        private readonly char[,] gameBoard = new char[25, 8];

        public char[,] GameBoard
        {
            get { 
                return gameBoard; 
            }
        } 


        /// <summary>
        /// Field to hold number of made player shoots
        /// </summary>
        private int shootCounter = 0;

        /// <summary>
        /// Filed to hold count of left balloons on game board
        /// </summary>
        private int baloonCounter = 50;

        /// <summary>
        /// Gets number of made player shoots
        /// </summary>
        public int ShootCounter
        {
            get
            {
                return this.shootCounter;
            }
        }

        /// <summary>
        /// Gets the left balloons on game board
        /// </summary>
        public int RemainingBaloons
        {
            get
            {
                return this.baloonCounter;
            }
        }

        /// <summary>
        /// Method for creating new game board
        /// </summary>
        public void GenerateNewGameBoard()
        {
            this.FillBlankGameBoard();

            Random randomGenerator = new Random();
            Coordinates coordinates = new Coordinates();
            for (int col = 0; col < 10; col++)
            {
                for (int row = 0; row < 5; row++)
                {
                    coordinates.Col = col;
                    coordinates.Row = row;
                    char ballonColor = (char)(randomGenerator.Next(1, 5) + (int)'0');
                    this.AddNewBaloonToGameBoard(coordinates, ballonColor);
                }
            }
        }

        /// <summary>
        /// Method for count and mark hit balloons
        /// </summary>
        /// <param name="currentCoordinates">Position of the user hit.</param>
        public void ShootBaloons(Coordinates currentCoordinates)
        {
            char currentBaloon;
            currentBaloon = this.GetBaloonColor(currentCoordinates);

            if (currentBaloon < '1' || currentBaloon > '4')
            {
                throw new BaloonsPop.Exceptions.PopedBallonException("Cannot pop missing ballon!");
            }

            this.AddNewBaloonToGameBoard(currentCoordinates, '.');
            this.baloonCounter--;

            this.PopLeftAndRightNeighbor(currentCoordinates, currentBaloon);

            this.PopUpAndDownNeighbors(currentCoordinates, currentBaloon);

            this.shootCounter++;
            this.LandFlyingBaloons();
        }

        /// <summary>
        /// Method for printing game board
        /// </summary>
        public void PrintGameBoard()
        {
            StringBuilder gameBoardAsString = new StringBuilder();

            gameBoardAsString.AppendLine();
            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 25; row++)
                {
                    gameBoardAsString.Append(this.gameBoard[row, col]);
                }

                gameBoardAsString.AppendLine();
            }

            Console.WriteLine(gameBoardAsString);
        }

        /// <summary>
        /// Method for adding balloon on exact coordinates
        /// </summary>
        /// <param name="coordinates">Exact coordinates for adding balloon on game board</param>
        /// <param name="ballonColor">Balloon color</param>
        private void AddNewBaloonToGameBoard(Coordinates coordinates, char ballonColor)
        {
            int xPosition, yPosition;
            xPosition = 4 + (coordinates.Col * 2);
            yPosition = 2 + coordinates.Row;
            this.gameBoard[xPosition, yPosition] = ballonColor;
        }

        /// <summary>
        /// Get color of balloon on exact coordinates
        /// </summary>
        /// <param name="coordinates">Coordinates on game board</param>
        /// <returns>Balloon color assign to asked coordinates</returns>
        private char GetBaloonColor(Coordinates coordinates)
        {
            int xPosition = 4 + (coordinates.Col * 2);
            int yPosition = 2 + coordinates.Row;

            char ballonColor = this.gameBoard[xPosition, yPosition];
            return ballonColor;
        }

        /// <summary>
        /// Method for filling game board with blank spaces, make game board notation and adding walls.
        /// </summary>
        private void FillBlankGameBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 25; col++)
                {
                    this.gameBoard[col, row] = ' ';
                }
            }

            char boardNotation = '0';

            for (int col = 4; col < 25; col++)
            {
                if ((col % 2 == 0) && boardNotation <= '9')
                {
                    this.gameBoard[col, 0] = boardNotation++;
                }

                this.gameBoard[col - 1, 1] = '-';
                this.gameBoard[col - 1, 7] = '-';
            }

            boardNotation = '0';

            for (int row = 2; row < 8; row++)
            {
                if (boardNotation <= '4')
                {
                    this.gameBoard[0, row] = boardNotation++;
                }

                if (row < 7)
                {
                    this.gameBoard[24, row] = '|';
                    this.gameBoard[2, row] = '|';
                }
            }
        }

        /// <summary>
        /// Method for count and mark hit horizontal balloons 
        /// </summary>
        /// <param name="currentCoordinates">Position of the user hit.</param>
        /// <param name="currentBaloon">Balloon color of user hit.</param>
        private void PopUpAndDownNeighbors(Coordinates currentCoordinates, char currentBaloon)
        {
            Coordinates neighborCoordinates = new Coordinates();

            neighborCoordinates.Col = currentCoordinates.Col;
            neighborCoordinates.Row = currentCoordinates.Row - 1;
            while (currentBaloon == this.GetBaloonColor(neighborCoordinates))
            {
                this.AddNewBaloonToGameBoard(neighborCoordinates, '.');
                this.baloonCounter--;
                neighborCoordinates.Row--;
            }

            neighborCoordinates.Col = currentCoordinates.Col;
            neighborCoordinates.Row = currentCoordinates.Row + 1;
            while (currentBaloon == this.GetBaloonColor(neighborCoordinates))
            {
                this.AddNewBaloonToGameBoard(neighborCoordinates, '.');
                this.baloonCounter--;
                neighborCoordinates.Row++;
            }
        }

        /// <summary>
        /// Method for count and mark hit vertical balloons 
        /// </summary>
        /// <param name="currentCoordinates">Position of the user hit.</param>
        /// <param name="currentBaloon">Balloon color of user hit.</param>
        private void PopLeftAndRightNeighbor(Coordinates currentCoordinates, char currentBaloon)
        {
            Coordinates neighborCoordinates = new Coordinates();

            neighborCoordinates.Col = currentCoordinates.Col - 1;
            neighborCoordinates.Row = currentCoordinates.Row;
            while (currentBaloon == this.GetBaloonColor(neighborCoordinates))
            {
                this.AddNewBaloonToGameBoard(neighborCoordinates, '.');
                this.baloonCounter--;
                neighborCoordinates.Col--;
            }

            neighborCoordinates.Col = currentCoordinates.Col + 1;
            neighborCoordinates.Row = currentCoordinates.Row;
            while (currentBaloon == this.GetBaloonColor(neighborCoordinates))
            {
                this.AddNewBaloonToGameBoard(neighborCoordinates, '.');
                this.baloonCounter--;
                neighborCoordinates.Col++;
            }
        }

        /// <summary>
        /// Method for swap balloons position.
        /// </summary>
        /// <param name="currentCoordinates">Current coordinate</param>
        /// <param name="newCoordinates">New coordinate for swap</param>
        private void SwapBaloonsPosition(Coordinates currentCoordinates, Coordinates newCoordinates)
        {
            char currentBallon = this.GetBaloonColor(currentCoordinates);
            this.AddNewBaloonToGameBoard(currentCoordinates, this.GetBaloonColor(newCoordinates));
            this.AddNewBaloonToGameBoard(newCoordinates, currentBallon);
        }

        /// <summary>
        /// Method for moving down on free spaces balloons
        /// </summary>
        private void LandFlyingBaloons()
        {
            Coordinates currentCoordinates = new Coordinates();
            for (int col = 0; col < 10; col++)
            {
                for (int row = 0; row <= 4; row++)
                {
                    currentCoordinates.Col = col;
                    currentCoordinates.Row = row;
                    if (this.GetBaloonColor(currentCoordinates) == '.')
                    {
                        for (int rowIndex = row; rowIndex > 0; rowIndex--)
                        {
                            Coordinates oldCoordinates = new Coordinates();
                            Coordinates newCoordinates = new Coordinates();
                            oldCoordinates.Col = col;
                            oldCoordinates.Row = rowIndex;
                            newCoordinates.Col = col;
                            newCoordinates.Row = rowIndex - 1;
                            this.SwapBaloonsPosition(oldCoordinates, newCoordinates);
                        }
                    }
                }
            }
        }
    }
}