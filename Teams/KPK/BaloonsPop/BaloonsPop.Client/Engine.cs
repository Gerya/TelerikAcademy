//-----------------------------------------------------------------------
// <copyright file="Engine.cs" company="Telerik">
// Group: Zirconium
// Project: Game Balloons Pop
// Copyright (c) 2013 Telerik. All rights reserved.
//
// </copyright>
//-----------------------------------------------------------------------

namespace BaloonsPop.Client
{
    using System;
    using BaloonsPop.Exceptions;

    /// <summary>
    /// Class for rule and control over game logic.
    /// </summary>
    internal class Engine
    {
        /// <summary>
        /// Private field assigned with value true run method.
        /// </summary>
        private GameBoardManager gameBoardManager;

        /// <summary>
        /// Run method start and control game logic.
        /// </summary>
        /// <param name="gameBoardManager">Take instance of GameBoardManager from the main method.</param>
        public void Run(GameBoardManager gameBoardManager)
        {
            this.gameBoardManager = gameBoardManager;
            bool isCoordinates;
            bool isCommand;
            Coordinates coordinates = new Coordinates();
            Command command = new Command();
            //TopScore topScore = new TopScore();
            TopScore.Instance.OpenTopScoreList();
            

            while (this.gameBoardManager.RemainingBaloons > 0)
            {
                Console.Write("Enter a row and column: ");
                string consoleInput = Console.ReadLine();

                isCoordinates = Coordinates.TryParse(consoleInput, ref coordinates);
                isCommand = Command.TryParse(consoleInput, ref command);

                if (isCoordinates)
                {
                    try
                    {
                        this.gameBoardManager.ShootBaloons(coordinates);
                    }
                    catch (PopedBallonException exp)
                    {
                        Console.WriteLine(exp.Message);
                    }

                    this.gameBoardManager.PrintGameBoard();
                }
                else if (isCommand)
                {
                    switch (command.Value)
                    {
                        case CommandTypes.Top:
                            TopScore.Instance.PrintScoreList();
                            break;
                        case CommandTypes.Restart:
                            this.gameBoardManager.GenerateNewGameBoard();
                            this.gameBoardManager.PrintGameBoard();
                            break;
                        case CommandTypes.Exit:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("The input isn't in correct format!");
                }
            }

            this.CheckTopScore();
        }

        /// <summary>
        /// Check if player is Top Scorer and if true add him/her to Top Scored Players
        /// </summary>
        private void CheckTopScore()
        {
            Player player = new Player();
            player.Score = this.gameBoardManager.ShootCounter;

            if (TopScore.Instance.IsTopScore(player))
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");
                string playerName = Console.ReadLine();
                player.Name = playerName;
                TopScore.Instance.AddToTopScoreList(player);
            }

            TopScore.Instance.SaveTopScoreList();
            TopScore.Instance.PrintScoreList();
        }
    }
}
