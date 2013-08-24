//-----------------------------------------------------------------------
// <copyright file="TopScore.cs" company="Telerik">
// Group: Zirconium
// Project: Game Balloons Pop
// Copyright (c) 2013 Telerik. All rights reserved.
//
// </copyright>
//-----------------------------------------------------------------------

namespace BaloonsPop.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class for managing top score list.
    /// </summary>
    public class TopScore
    {
        private const int MaxTopScoreCount = 5;
        private const string FilePath = "..\\..\\TopScore.txt";
        private static readonly TopScore instance;
        private static readonly List<Player> topScoreList = new List<Player>();

        /// <summary>
        /// Initializes a new instance of Class and set new instance of class to private field.
        /// To make class testable.
        /// </summary>
        static TopScore()
        {
            instance = new TopScore();
        }

        /// <summary>
        /// Gets private filed set in constructor.
        /// </summary>
        public static TopScore Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets the top score list. Used for easy testing.
        /// </summary>
        public List<Player> TopScoreList
        {
            get
            {
                return topScoreList;
            }
        }
        /// <summary>
        /// Checks if person is among top score players
        /// </summary>
        /// <param name="person">Player to check is top scored</param>
        /// <returns>
        /// True if person is top score player
        /// False if person is not a top score player
        /// </returns>
        public bool IsTopScore(Player person)
        {
            if (topScoreList.Count >= MaxTopScoreCount)
            {
                int lastTopScorePlayer = MaxTopScoreCount - 1;
                topScoreList.Sort();
                if (topScoreList[lastTopScorePlayer] > person)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Adds a player to top score list
        /// </summary>
        /// <param name="person">Top score player</param>
        public void AddToTopScoreList(Player person)
        {
            topScoreList.Add(person);
            topScoreList.Sort();
            while (topScoreList.Count > 5)
            {
                topScoreList.RemoveAt(5);
            }
        }

        /// <summary>
        /// Loads top score list from file into the program memory
        /// </summary>
        public void OpenTopScoreList()
        {
            using (StreamReader topScoreStreamReader = new StreamReader(FilePath))
            {
                string line = topScoreStreamReader.ReadLine();
                while (line != null)
                {
                    char[] separators = { ' ' };
                    string[] substrings = line.Split(separators);
                    int substringsCount = substrings.Count<string>();

                    if (substringsCount > 0)
                    {
                        string playerName = substrings[1];
                        string playerScore = substrings[substringsCount - 2];
                        Player player = new Player();
                        player.Name = playerName;
                        player.Score = int.Parse(playerScore);

                        topScoreList.Add(player);
                    }

                    line = topScoreStreamReader.ReadLine();
                }
            }
        }

        /// <summary>
        /// Saves top score list into a file
        /// </summary>
        public void SaveTopScoreList()
        {
            if (topScoreList.Count > 0)
            {
                StringBuilder toWriteInFile = new StringBuilder();

                using (StreamWriter topScoreStreamReader = new StreamWriter("..\\..\\TopScore.txt"))
                {
                    for (int index = 0; index < topScoreList.Count; index++)
                    {
                        toWriteInFile.AppendFormat("{0}. {1,-10}  --> {2,2} moves", index + 1, topScoreList[index].Name, topScoreList[index].Score);
                        toWriteInFile.AppendLine();
                    }

                    topScoreStreamReader.Write(toWriteInFile.ToString());
                }
            }
        }

        /// <summary>
        /// Clears the initial data in the class.
        /// </summary>
        public void Clear()
        {
            topScoreList.Clear();
        }

        /// <summary>
        /// Print top score list to the console
        /// </summary>
        public void PrintScoreList()
        {
            Console.WriteLine(TopScore.Renderer());
        }

        /// <summary>
        /// Renders top score list into a string
        /// </summary>
        /// <returns>ordered list to string</returns>
        private static string Renderer()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Scoreboard:");
            if (topScoreList.Count > 0)
            {
                for (int index = 0; index < topScoreList.Count; index++)
                {
                    result.AppendLine(
                        string.Format(
                        "{0}. {1,-10}  --> {2,2} moves",
                        index + 1,
                        topScoreList[index].Name,
                        topScoreList[index].Score));
                }
            }
            else
            {
                result.AppendLine("Scoreboard is empty");
            }

            return result.ToString();
        }
    }
}