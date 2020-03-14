using System;
using System.Collections.Generic;
using System.Text;

namespace VirusGame.Game
{
    class Game : IGame
    {
        private DiseaseParameters _disease = DiseaseParameters.Random();
        private PopulationParameters _population = PopulationParameters.Random();

        public GameState GetGameState()
        {
            return new GameState()
            {
                CuredPeopleCount = 0,
                DaysSinceOutbreak = 0,
                SickPeopleCount = 0,
                CountryPopulation = 0
            };
        }

        public bool IsGameLost()
        {
            return CountryPopulation == 0;
        }

        public bool IsGameWon()
        {
            return false;
        }

        public void NextDay()
        {
            throw new NotImplementedException();
        }
    }
}
