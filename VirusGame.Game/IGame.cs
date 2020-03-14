using System.Collections.Generic;

namespace VirusGame.Game
{
    public interface IGame
    {
        GameState GetGameState();

        void NextDay();

        bool IsGameLost();
        bool IsGameWon();
        void ApplyAction(int actionId);
        IEnumerable<VirusFightingAction> GetAvailableActions();
    }
}