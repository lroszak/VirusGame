using System;
using VirusGame.Game;

namespace VirusGame
{
    class Program
    {
        static void Main(string[] args)
        {
            _game = GameFactory.StartNewGame();

            while (true)
            {
                PrintCountryStats();

                if (_game.IsGameWon())
                {
                    Console.WriteLine("You won, your country is saved.");
                    break;
                }
                if (_game.IsGameLost())
                {
                    Console.WriteLine("You lost, you have died with other people.");
                    break;
                }

                ReadUserAction();

                _game.NextDay();
            }
        }

        private static void ReadUserAction()
        {
            int amountOfActions = 4;
            while (true)
            {
                Console.WriteLine("Please select your action");
                var text = Console.ReadLine();
                var isActionCorrect = int.TryParse(text, out int actionId);
                if(isActionCorrect && )
            }
        }

        public static IGame _game { get; private set; }


        public  static void PrintCountryStats()
        {
            Console.Clear();
        }
    }
}
