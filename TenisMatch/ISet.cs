namespace TennisMatch
{
    public interface ISet
    {
        void AddPoint(int gameWinnerPlayer);

        int GetWinnerPlayer();
    }
}
