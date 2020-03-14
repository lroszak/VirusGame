using System;
using System.Linq;
using System.Threading;
using VirusGame.Game;

namespace VirusGame
{
    class Program
    {
        static void Main(string[] args)
        {
            _game = GameFactory.StartNewGame();

            Console.WriteLine("You are a Prime Minister of Koronia, and your country is in danger!");
            Console.WriteLine("People are coming back from holiday infected, but you know nothing about it.");
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();
            
            while (true)
            {
                var gamestate = _game.GetGameState();
                if (gamestate.DaysSinceOutbreak > 0)
                {
                    Console.WriteLine($"It's been {gamestate.DaysSinceOutbreak} day{(gamestate.DaysSinceOutbreak>1? "s":"")} since virus infection in Koronia.");

                }
                PrintCountryStats();

                if (_game.IsGameWon())
                {
                    Console.WriteLine("You won, your country is saved.");
                    Console.WriteLine($"It took {_game.GetGameState().DaysSinceOutbreak} days to fight outbreak.");
                    break;
                }
                if (_game.IsGameLost())
                {
                    Console.WriteLine("You lost, you have died with other people.");
                    Console.WriteLine($"Your country survived {_game.GetGameState().DaysSinceOutbreak} days");
                    break;
                }

                if(gamestate.SickPeopleCount > 0)
                {
                    ReadUserAction();

                }
                else
                {
                    Thread.Sleep(150);
                }

                _game.NextDay();
                Console.Clear();
            }
        }

        private static void ReadUserAction()
        {
            var availableActions = _game.GetAvailableActions();
            while (true)
            {
                var actionIndex = 0;
                foreach (var action in availableActions)
                {
                    Console.WriteLine($"{actionIndex++}. {action.Description}");
                }
                Console.WriteLine("Please type your action number");
                
                var text = Console.ReadLine();
                var isActionCorrect = int.TryParse(text, out int actionId);
                if (isActionCorrect && actionId < availableActions.Count())
                {
                    _game.ApplyAction(actionId);
                    return;

                }
                else
                {
                    Console.WriteLine("Invalid action number");
                }
            }
        }

        public static IGame _game { get; private set; }


        public static void PrintCountryStats()
        {
            var gameState = _game.GetGameState();
            Console.WriteLine($"Population         : {gameState.CountryPopulation}");
            Console.WriteLine($"Sick People Count  : {gameState.SickPeopleCount}");
            Console.WriteLine($"Cured People Count : {gameState.CuredPeopleCount}");
            Console.WriteLine($"Dead People Count  : {gameState.DeadPeopleCount}");
        }
    }
}
