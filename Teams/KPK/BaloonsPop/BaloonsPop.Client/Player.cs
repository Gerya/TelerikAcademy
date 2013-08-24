//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="Telerik">
// Group: Zirconium
// Project: Game Balloons Pop
// Copyright (c) 2013 Telerik. All rights reserved.
//
// </copyright>
//-----------------------------------------------------------------------

namespace BaloonsPop.Client
{
    using System;

    /// <summary>
    /// Class for saving players status
    /// </summary>
    public class Player : IComparable
    {
        private string name;
        private int score;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Player name can not be set to null");
                }

                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Player score must be non negative number and smaller than Int.MaxValue");
                }

                this.score = value;
            }
        }

        /// <summary>
        /// Operator to compare players. Comparison is done by score.
        /// </summary>
        /// <returns>True if firsPlayer score is smaller than secondPlayer score</returns>
        public static bool operator <(Player firstPlayer, Player secondPlayer)
        {
            return firstPlayer.Score < secondPlayer.Score;
        }

        /// <summary>
        /// Operator to compare players. Comparison is done by score.
        /// </summary>
        /// <returns>True if firsPlayer score is bigger than secondPlayer score</returns>
        public static bool operator >(Player firstPlayer, Player secondPlayer)
        {
            return firstPlayer.Score > secondPlayer.Score;
        }

        /// <summary>
        /// Compare two players by their score so they can be ordered by .Net sorting methods.
        /// </summary>
        /// <param name="obj">Second player to be compared</param>
        /// <returns>
        /// Less than zero if this instance precedes player in the sort order.
        /// Zero if this instance occurs in the same position in the sort order as player.
        /// Greater than zero if this instance follows player in the sort order. 
        /// </returns>
        public int CompareTo(object obj)
        {
            Player secondPerson = obj as Player;

            if (secondPerson != null)
            {
                int result = this.Score.CompareTo(secondPerson.Score);
                return result;
            }
            else
            {
                throw new FormatException("You can compare only persons socore.");
            }
        }
    }
}