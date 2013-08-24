using BaloonsPop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsPop.Tests
{
    [TestClass]
    public class TopScoreTest
    {
        private static void Add12345ToTopScoreList(TopScore topScore)
        {
            for (int i = 1; i <= 5; i++)
            {
                Player player = new Player();
                player.Score = i;
                topScore.AddToTopScoreList(player);
            }
        }

        [TestMethod]
        public void AddToTopScoreList_ValidInput_Test()
        {
            TopScore.Instance.Clear();
            Add12345ToTopScoreList(TopScore.Instance);

            Player testPlayer = new Player();
            testPlayer.Score = 3;
            TopScore.Instance.AddToTopScoreList(testPlayer);

            bool result = (TopScore.Instance.TopScoreList.Count > 5);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTopScore_ValidInput_Test()
        {
            TopScore.Instance.Clear();
            TopScore newTopScore = new TopScore();
            Add12345ToTopScoreList(newTopScore);

            Player testPlayer = new Player();
            testPlayer.Score = 0;
            bool result = newTopScore.IsTopScore(testPlayer);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTopScore_InValidInput_Test()
        {
            TopScore.Instance.Clear();
            TopScore newTopScore = new TopScore();
            Add12345ToTopScoreList(newTopScore);

            Player testPlayer = new Player();
            testPlayer.Score = 9;
            bool result = newTopScore.IsTopScore(testPlayer);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTopScore_ListNotFull_Test()
        {
            TopScore.Instance.Clear();
            Player testPlayer = new Player();
            testPlayer.Score = 9;
            bool result = TopScore.Instance.IsTopScore(testPlayer);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OpenTopScoreList_ValidFile_Test()
        {
            TopScore.Instance.OpenTopScoreList();
        }

        [TestMethod]
        public void SaveTopScoreList_ValidFile_Test()
        {
            TopScore.Instance.SaveTopScoreList();
        }
    }
}