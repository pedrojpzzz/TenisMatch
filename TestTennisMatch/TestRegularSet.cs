using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisMatch;

namespace TestTennisMatch
{
    [TestClass]
    public class TestRegularSet
    {
        [TestMethod]
        public void TestAddGame_Player1Wins6Games_Player1WinsSet()
        {
            var set = new RegularSet();

            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);

            Assert.AreEqual(0, set.GetWinnerPlayer());
        }

        [TestMethod]
        public void TestAddGame_Player1Wins6GamesPlayer2Wins5Games_NoWinner()
        {
            var set = new RegularSet();

            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);

            set.AddGame(1);
            set.AddGame(1);
            set.AddGame(1);
            set.AddGame(1);
            set.AddGame(1);

            set.AddGame(0);

            Assert.AreEqual(-1, set.GetWinnerPlayer());
        }

        [TestMethod]
        public void TestAddGame_Player1Wins5GamesPlayer2Wins7Games_Player2WinsSet()
        {
            var set = new RegularSet();

            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);
            set.AddGame(0);

            set.AddGame(1);
            set.AddGame(1);
            set.AddGame(1);
            set.AddGame(1);
            set.AddGame(1);
            set.AddGame(1);
            set.AddGame(1);

            Assert.AreEqual(1, set.GetWinnerPlayer());
        }
    }
}
