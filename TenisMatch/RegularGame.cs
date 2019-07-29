namespace TennisMatch
{
    public class RegularGame : IGame
    {
        enum GamePoint { Zero, Fifteen, Thirty, Fourty, ADV };

        GamePoint[] GameScoreboard;
        int GameWinnerPlayer;

        public RegularGame()
        {
            ResetGameScoreboard();
        }

        public void ResetGameScoreboard()
        {
            GameScoreboard = new GamePoint[2];
            GameScoreboard[0] = GamePoint.Zero;
            GameScoreboard[1] = GamePoint.Zero;
            GameWinnerPlayer = -1;
        }

        private void PlayerWinsGame(int player)
        {
            GameWinnerPlayer = player;

            TennisMatchScore.AddTotalGamesToPlayer(player);
        }

        public int GetWinnerPlayer()
        {
            return GameWinnerPlayer;
        }

        public void AddPoint(int pointWinnerPlayer)
        {
            if (GameWinnerPlayer == -1)
            {
                int otherPlayer = GetOtherPlayerIndex(pointWinnerPlayer);

                if (((GameScoreboard[pointWinnerPlayer] == GamePoint.Fourty) && (GameScoreboard[otherPlayer] <= GamePoint.Thirty))
                    || ((GameScoreboard[pointWinnerPlayer] == GamePoint.ADV) && (GameScoreboard[otherPlayer] == GamePoint.Fourty)))
                {
                    PlayerWinsGame(pointWinnerPlayer);
                }
                else if ((GameScoreboard[pointWinnerPlayer] == GamePoint.Fourty) && (GameScoreboard[otherPlayer] == GamePoint.ADV))
                {
                    GameScoreboard[otherPlayer] = GamePoint.Fourty;
                }
                else
                {
                    GameScoreboard[pointWinnerPlayer] += 1;
                }
            }
        }

        private int GetOtherPlayerIndex(int player)
        {
            return player == 1 ? 0 : 1;
        }
    }
}
