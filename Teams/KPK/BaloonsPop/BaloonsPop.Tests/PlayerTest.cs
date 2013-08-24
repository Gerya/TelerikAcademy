using System;
using BaloonsPop.Client;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsPop.Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Player_ValidName_Set()
        {
            Player testPlayer = new Player();
            string input = "Natalya";
            testPlayer.Name = input;
            Assert.AreEqual(input, testPlayer.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Player_NullNameValue_Set()
        {
            Player testPlayer = new Player();
            string input = null;
            testPlayer.Name = input;
        }

        [TestMethod]
        public void Player_MaxScoreValue_Set()
        {
            Player testPlayer = new Player();
            int input = int.MaxValue;
            testPlayer.Score = input;
            Assert.AreEqual(input, testPlayer.Score);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Player_NegativeScoreValue_Set()
        {
            Player testPlayer = new Player();
            int input = -5;
            testPlayer.Score = input;
        }

        [TestMethod]
        public void Player_ComparisonOperator_Smaller()
        {
            Player firstPlayer = new Player();
            firstPlayer.Score = 1;
            Player secondPlayer = new Player();
            secondPlayer.Score = 2;
            Assert.IsTrue(firstPlayer < secondPlayer);
        }

        [TestMethod]
        public void Player_ComparisonOperator_Bigger()
        {
            Player firstPlayer = new Player();
            firstPlayer.Score = 1;
            Player secondPlayer = new Player();
            secondPlayer.Score = 2;
            Assert.IsFalse(firstPlayer > secondPlayer);
        }

        [TestMethod]
        public void Player_ValidCompareToMethod_Test()
        {
            List<Player> scoreList = new List<Player>();

            Player firstPlayer = new Player();
            firstPlayer.Score = 3;
            scoreList.Add(firstPlayer);

            Player secondPlayer = new Player();
            secondPlayer.Score = 1;
            scoreList.Add(secondPlayer);

            Player thirdPlayer = new Player();
            thirdPlayer.Score = 2;
            scoreList.Add(thirdPlayer);

            scoreList.Sort();

            for (int playerIndex = 0; playerIndex < scoreList.Count; playerIndex++)
            {
                Assert.AreEqual(playerIndex + 1, scoreList[playerIndex].Score);
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Player_InValidCompareToMethod_Test()
        {
            Player firstPlayer = new Player();
            firstPlayer.Score = 1;
            firstPlayer.CompareTo(4);
        }
    }
}
