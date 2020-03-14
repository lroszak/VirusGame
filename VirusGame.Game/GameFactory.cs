using System;

namespace VirusGame.Game
{
    public class GameFactory
    {
        public static IGame StartNewGame()
        {
            return new Game();
        }
    }
}
