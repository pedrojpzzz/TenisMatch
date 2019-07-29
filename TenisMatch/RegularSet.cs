using System;

namespace TennisMatch
{
    public class RegularSet : ISet
    {
        const int MINGAMESTOWIN = 6;
        const int MINGAMESDIFF = 2;

        
        int[] GameScoreboard;
        int SetWinnerPlayer;
        IGame Game;

        public RegularSet()
        {
            ResetScoreBoard();
        }

        private void ResetScoreBoard()
        {
            GameScoreboard = new int[2];
            GameScoreboard[0] = 0;
            GameScoreboard[1] = 0;

            SetWinnerPlayer = -1;
            Game = new RegularGame();
        }

        public void AddPoint(int pointWinnerPlayer)
        {
            Game.AddPoint(pointWinnerPlayer);

            if(Game.GetWinnerPlayer() != -1)
            {
                AddGame(pointWinnerPlayer);
                Game = new RegularGame();
            }
        }

        internal void AddGame(int gameWinnerPlayer)
        {
            if (SetWinnerPlayer == -1)
            {
                GameScoreboard[gameWinnerPlayer] += 1;

                int winnerPlayerGames = GameScoreboard[gameWinnerPlayer];
                int otherPlayerGames = GameScoreboard[GetOtherPlayerIndex(gameWinnerPlayer)];

                int GamesDiff = Math.Abs(winnerPlayerGames - otherPlayerGames);

                if ((winnerPlayerGames > otherPlayerGames) && (winnerPlayerGames >= MINGAMESTOWIN) && (GamesDiff >= MINGAMESDIFF))
                {
                    SetWinnerPlayer = gameWinnerPlayer;
                }
            }
        }

        public int GetWinnerPlayer()
        {
            return SetWinnerPlayer;
        }

        private int GetOtherPlayerIndex(int player)
        {
            return player == 1 ? 0 : 1;
        }

    }
}
