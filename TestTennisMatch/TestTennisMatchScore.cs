using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisMatch;

namespace TestTennisMatch
{
    [TestClass]
    public class TestTennisMatchScore
    {
        [TestMethod]
        public void TestCalculateSetsToWin_Max5Sets_SetsToWinEquals3()
        {
            var tennisMatchScore = new TennisMatchScore(5);

            Assert.AreEqual(3, tennisMatchScore.SetsToWin);
        }

        [TestMethod]
        public void TestCalculateSetsToWin_Max1Set_SetsToWinEquals1()
        {
            var tennisMatchScore = new TennisMatchScore(1);

            Assert.AreEqual(1, tennisMatchScore.SetsToWin);
        }

        [TestMethod]
        public void TestPlayerWinsSet_Player1wins3Sets_Player1WinsMatch()
        {
            var tennisMatchScore = new TennisMatchScore(3);

            tennisMatchScore.PlayerWinsSet(0);
            tennisMatchScore.PlayerWinsSet(0);
            tennisMatchScore.PlayerWinsSet(0);

            Assert.AreEqual(0, tennisMatchScore.MatchWinnerPlayer);
        }
    }
}
