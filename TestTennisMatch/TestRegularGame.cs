using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisMatch;

namespace TestTennisMatch
{
    [TestClass]
    public class TestRegularGame
    { 
        [TestMethod]
        public void TestAddPoint_Player1Wins3Points_NoWinner()
        {
            var game = new RegularGame();

            game.AddPoint(0);
            game.AddPoint(0);
            game.AddPoint(0);

            Assert.AreEqual(-1, game.GetWinnerPlayer());
        }

        [TestMethod]
        public void TestAddPoint_Player1Wins4PointsPlayer2Wins3_NoWinner()
        {
            var game = new RegularGame();

            game.AddPoint(0);
            game.AddPoint(0);
            game.AddPoint(0);

            game.AddPoint(1);
            game.AddPoint(1);
            game.AddPoint(1);

            game.AddPoint(0);

            Assert.AreEqual(-1, game.GetWinnerPlayer());
        }

        [TestMethod]
        public void TestAddPoint_Player1ScoresPointWithAdvantage_Player1Wins()
        {
            var game = new RegularGame();

            game.AddPoint(0);
            game.AddPoint(0);
            game.AddPoint(0);

            game.AddPoint(1);
            game.AddPoint(1);
            game.AddPoint(1);

            game.AddPoint(0);
            game.AddPoint(0);

            Assert.AreEqual(0, game.GetWinnerPlayer());
        }

        [TestMethod]
        public void TestAddPoint_Player2ComesBackAfterPlayer1Advantage_Player2Wins()
        {
            var game = new RegularGame();

            game.AddPoint(0);
            game.AddPoint(0);
            game.AddPoint(0);

            game.AddPoint(1);
            game.AddPoint(1);
            game.AddPoint(1);

            game.AddPoint(0);

            game.AddPoint(1);
            game.AddPoint(1);
            game.AddPoint(1);

            Assert.AreEqual(1, game.GetWinnerPlayer());
        }
    }
}
