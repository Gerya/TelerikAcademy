//-----------------------------------------------------------------------
// <copyright file="Coordinates.cs" company="Telerik">
// Group: Zirconium
// Project: Game Balloons Pop
// Copyright (c) 2013 Telerik. All rights reserved.
//
// </copyright>
//-----------------------------------------------------------------------

namespace BaloonsPop.Client
{
    using System.Linq;

    /// <summary>
    /// Structure for the coordinates that are necessary for playing the game. 
    /// </summary>
    public struct Coordinates
    {
        /// <summary>
        /// Constant that shows the maximum value of the columns in the game.
        /// </summary>
        private const int MaxCols = 9;

        /// <summary>
        /// Constant that shows the maximum value of the rows in the game.
        /// </summary>
        private const int MaxRows = 4;

        /// <summary>
        /// Field to hold value of the columns.
        /// </summary>
        private int col;

        /// <summary>
        /// Field to hold value of the rows.
        /// </summary>
        private int row;

        /// <summary>
        /// Gets or sets the value of the column.
        /// </summary>
        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                this.col = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the row.
        /// </summary>
        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        /// <summary>
        /// Tries to parse the input.
        /// </summary>
        /// <param name="input">String that should be parsed.</param>
        /// <param name="result">Coordinates that should be set a value.</param>
        /// <returns>Boolean value that shows is the parse successful.</returns>
        public static bool TryParse(string input, ref Coordinates result)
        {
            char[] separators = { ' ', ',' };
            string[] substrings = input.Split(separators);

            if (substrings.Count<string>() != 2)
            {
                return false;
            }

            string coordinateRow = substrings[0].Trim();
            int row;
            if (int.TryParse(coordinateRow, out row))
            {
                if (row >= 0 && row <= MaxRows)
                {
                    result.Row = row;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            string coordinateCol = substrings[1].Trim();
            int col;
            if (int.TryParse(coordinateCol, out col))
            {
                if (col >= 0 && col <= MaxCols)
                {
                    result.Col = col;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}