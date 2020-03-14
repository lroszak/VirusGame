using System;
using System.Collections.Generic;
using System.Text;

namespace VirusGame.Game
{
    class Game : IGame
    {
        private DiseaseParameters _disease = DiseaseParameters.Random();
        private PopulationParameters _population = PopulationParameters.Random();
        private List<VirusFightingAction> availableActions = new List<VirusFightingAction>();
        private List<VirusFightingAction> implementedActions = new List<VirusFightingAction>();
        private int DaysSinceOutbreak = 0;


        internal Game()
        {
            availableActions.Add(new DoNothingAction());
            availableActions.Add(new CloseShopsAction());
            availableActions.Add(new CloseSchoolsAction());
            availableActions.Add(new CloseRoadsAction());
        }

        public void ApplyAction(int actionId)
        {
            if (actionId > 0)
            {
                implementedActions.Add(availableActions[actionId]);

                availableActions.RemoveAt(actionId);
            }
        }

        public IEnumerable<VirusFightingAction> GetAvailableActions()
        {
            return availableActions.AsReadOnly();
        }

        public GameState GetGameState()
        {
            return new GameState()
            {
                CuredPeopleCount = 0,
                DaysSinceOutbreak = DaysSinceOutbreak,
                SickPeopleCount = 0,
                CountryPopulation = _population.Population
            };
        }

        public bool IsGameLost()
        {
            return GetGameState().CountryPopulation == 0;
        }

        public bool IsGameWon()
        {
            return false;
        }

        public void NextDay()
        {
            DaysSinceOutbreak++;
        }
    }
}
