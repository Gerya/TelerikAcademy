//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="Telerik">
// Group: Zirconium
// Project: Game Balloons Pop
// Copyright (c) 2013 Telerik. All rights reserved.
//
// </copyright>
//-----------------------------------------------------------------------

namespace BaloonsPop.Client
{

    /// <summary>
    /// Class for commands to use in the game.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Gets and sets the type of the command.
        /// </summary>
        public CommandTypes Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Tries to parse the input.
        /// </summary>
        /// <param name="input">String that should be parsed.</param>
        /// <param name="command">Command that should be set a value.</param>
        /// <returns>Boolean value that shows is the parse successful.</returns>
        public static bool TryParse(string input, ref Command command)
        {
            bool parseResult = false;

            if (input == CommandTypes.Top.ToString())
            {
                command.Value = CommandTypes.Top;
                parseResult = true;
            }
            else if (input == CommandTypes.Restart.ToString())
            {
                command.Value = CommandTypes.Restart;
                parseResult = true;
            }
            else if (input == CommandTypes.Exit.ToString())
            {
                command.Value = CommandTypes.Exit;
                parseResult = true;
            }

            return parseResult;
        }
    }
}