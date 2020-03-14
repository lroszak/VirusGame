using NUnit.Framework;
using VirusGame.Game;

namespace VirusGame.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Timeout(100000)]
        public void JustDoNothing_AndGameShouldEnd()
        {
            for (int i = 0; i < 100; i++)
            {
                var game = GameFactory.StartNewGame();

                while (!game.IsGameLost() && !game.IsGameWon())
                {
                    game.NextDay();
                }
            }
        }

        [Test]
        [Timeout(100000)]
        public void JustDoNothing_AndGameShouldProduceRandomEffectsWhenYouDoNothing()
        {
            int gamesWon = 0;
            int gamesLost = 0;
            for (int i = 0; i < 100; i++)
            {
                var game = GameFactory.StartNewGame();

                while (!game.IsGameLost() && !game.IsGameWon())
                {
                    game.NextDay();
                    game.GetGameState();
                }
                if (game.IsGameLost())
                {
                    gamesLost++;
                }
                if (game.IsGameWon())
                {
                    gamesWon++;
                }
            }

            //Assert
            Assert.IsTrue(gamesLost > 0);
            Assert.IsTrue(gamesWon > 0);
        }
    }
}