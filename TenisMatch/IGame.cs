namespace TennisMatch
{
    public interface IGame
    {
        void AddPoint(int pointWinnerPlayer);

        int GetWinnerPlayer();
    }
}
