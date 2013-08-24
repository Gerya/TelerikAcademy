//-----------------------------------------------------------------------
// <copyright file="BaloonsPopMain.cs" company="Telerik">
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
    /// Main class for starting game.
    /// </summary>
    public class BaloonsPopMain
    {
        /// <summary>
        /// Main method make initialization of main classes, call engine to start the game and print welcome message.
        /// </summary>
        internal static void Main()
        {
            PrintWelcomeMessage();

            GameBoardManager gameBoardManager = new GameBoardManager();
            gameBoardManager.GenerateNewGameBoard();
            gameBoardManager.PrintGameBoard();

            Engine egine = new Engine();
            egine.Run(gameBoardManager);
        }

        /// <summary>
        /// Method for printing welcome message.
        /// </summary>
        private static void PrintWelcomeMessage()
        {
            StringBuilder welcomeMsg = new StringBuilder();

            welcomeMsg.AppendLine("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            welcomeMsg.AppendLine("---------------------------------------------------------------");
            welcomeMsg.AppendLine("Commands:");
            welcomeMsg.AppendLine("'top'     to view the top scoreboard");
            welcomeMsg.AppendLine("'restart' to start a new game");
            welcomeMsg.AppendLine("'exit'    to quit the game");
            welcomeMsg.AppendLine("---------------------------------------------------------------");

            Console.WriteLine(welcomeMsg);
        }
    }
}
