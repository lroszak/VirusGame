namespace VirusGame.Game
{
    public interface IGame
    {
        GameState GetGameState();

        void NextDay();

        bool IsGameLost();
        bool IsGameWon();
    }
}