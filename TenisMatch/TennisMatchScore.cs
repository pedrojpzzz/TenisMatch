namespace TennisMatch
{
    public class TennisMatchScore
    {
        const int MAXPOINTS = 1000000;

        int[] SetScoreboard;
        static int[] PlayersTotalPoints;
        static int[] PlayersTotalGames;
        
        int MaxSets;
        internal int SetsToWin;
        internal int MatchWinnerPlayer;

        ISet set;

        public TennisMatchScore(int maxSets)
        {
            MaxSets = maxSets;
            MatchWinnerPlayer = -1;

            set = new RegularSet();
            CalculateSetsToWin();
            StartMatch();
        }

        private void CalculateSetsToWin()
        {
            SetsToWin = (MaxSets / 2) + 1;
        }

        public void StartMatch()
        {
            ResetScoreBoard();
            ResetPlayersTotalPoints();
        }

        private void ResetScoreBoard()
        {
            SetScoreboard = new int[2];
            SetScoreboard[0] = 0;
            SetScoreboard[1] = 0;
        }

        private void ResetPlayersTotalPoints()
        {
            PlayersTotalPoints = new int[2];
            PlayersTotalPoints[0] = 0;
            PlayersTotalPoints[1] = 0;

            PlayersTotalGames = new int[2];
            PlayersTotalGames[0] = 0;
            PlayersTotalGames[1] = 0;
        }

        public static void AddTotalGamesToPlayer(int player)
        {
            PlayersTotalGames[player] += 1;
        }

        public void AddPoint(int pointWinnerPlayer)
        {
            PlayersTotalPoints[pointWinnerPlayer] += 1;
            set.AddPoint(pointWinnerPlayer);

            if(set.GetWinnerPlayer() != -1)
            {
                PlayerWinsSet(pointWinnerPlayer);
                set = new RegularSet();
            }
        }

        private int GetWinnerPlayer()
        {
            if (PlayersTotalPoints[0] + PlayersTotalPoints[1] < MAXPOINTS)
            {


                if (SetScoreboard[0] > SetScoreboard[1])
                { return 0; }
                else if (SetScoreboard[1] > SetScoreboard[0])
                { return 1; }
                else
                {
                    if (PlayersTotalGames[0] > PlayersTotalGames[1])
                    { return 0; }
                    else if (PlayersTotalGames[1] > PlayersTotalGames[0])
                    { return 1; }
                    else
                    {
                        if (PlayersTotalPoints[0] > PlayersTotalPoints[1])
                        { return 0; }
                        else if (PlayersTotalPoints[1] > PlayersTotalPoints[0])
                        { return 1; }
                        else return -1;
                    }
                }
            }
            else
            {
                return MatchWinnerPlayer;
            }
        }

        internal void PlayerWinsSet(int setWinnerPlayer)
        {
            if (MatchWinnerPlayer == -1)
            {
                SetScoreboard[setWinnerPlayer] += 1;

                if (SetScoreboard[setWinnerPlayer] == SetsToWin)
                {
                    MatchWinnerPlayer = setWinnerPlayer;
                }
            }
        }
    }
}
