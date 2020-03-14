using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirusGame.Game.VirusFightingActions;

namespace VirusGame.Game
{
    class Game : IGame
    {
        private DiseaseParameters _initialDisease = DiseaseParameters.Random();
        private DiseaseParameters _disease
        {
            get
            {
                var diseaseParameters = _initialDisease;
                foreach (var action in implementedActions)
                {
                    diseaseParameters = action.ApplyAction(diseaseParameters);
                }
                return diseaseParameters;
            }
        }

        private PopulationParameters _initialPopulation = PopulationParameters.Random();
        private PopulationParameters _population
        {
            get
            {
                var populationParameters = _initialPopulation;
                foreach (var action in implementedActions)
                {
                    populationParameters = action.ApplyAction(populationParameters);
                }
                return populationParameters;
            }
        }
        private List<VirusFightingAction> availableActions = new List<VirusFightingAction>();
        private List<VirusFightingAction> implementedActions = new List<VirusFightingAction>();
        private int DaysSinceOutbreak = 0;

        private List<int> _healthyPeople = new List<int>();
        private List<int> _infectedPeople = new List<int>();
        private List<int> _sickPeople = new List<int>();
        private List<int> _recoveredPeople = new List<int>();
        private List<int> _deaths = new List<int>();

        internal Game()
        {
            availableActions.Add(new DoNothingAction());
            availableActions.Add(new CloseShopsAction());
            availableActions.Add(new CloseSchoolsAction());
            availableActions.Add(new CloseRoadsAction());
            availableActions.Add(new CloseBordersAction());
            availableActions.Add(new SuggestVitaminsAction());

            _healthyPeople.Add(_population.Population);
            _infectedPeople.Add(_disease.InitialAmountOfInfectedPeople);
            _sickPeople.Add(0);
            _recoveredPeople.Add(0);
            _deaths.Add(0);
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
                CuredPeopleCount = _recoveredPeople.Sum(),
                DaysSinceOutbreak = DaysSinceOutbreak,
                SickPeopleCount = GetAmountOfSickPeopleNow(),
                CountryPopulation = _population.Population - _deaths.Sum(),
                DeadPeopleCount = _deaths.Sum()
            };
        }

        private int GetAmountOfSickPeopleNow()
        {
            return _sickPeople.Where((item, indexer) => indexer > _sickPeople.Count - _disease.DaysForRecover).Sum();
        }

        private int GetAmountOfInfectedPeopleNow()
        {
            return _infectedPeople.Where((item, indexer) => indexer > _infectedPeople.Count - _disease.SymptomsDelayInDays).Sum();
        }

        private int GetAmountOfContageousPeopleNow()
        {
            return GetAmountOfSickPeopleNow() + GetAmountOfInfectedPeopleNow();
        }
        public bool IsGameLost()
        {
            return GetGameState().CountryPopulation == 0 || DaysSinceOutbreak > 365 * 2;
        }

        public bool IsGameWon()
        {
            return GetAmountOfContageousPeopleNow() == 0;
        }

        public void NextDay()
        {
            DaysSinceOutbreak++;
            if(DaysSinceOutbreak == 30)
            {
                availableActions.Add(new VaccinateAction());
            }
            if (DaysSinceOutbreak == 60)
            {
                availableActions.Add(new InventMedicineAction());
            }

            var infectedToday = CalculateInfectedPeopleInADay();
            var gotSickToday = CalculateConvertedFromInfectedToSick();
            var gotRecoveredToday = CalculateRecoveredToday();
            var gotDeadToday = CalculateDeadToday();

            
            _infectedPeople.Add(infectedToday);
            _sickPeople.Add(gotSickToday);
            _recoveredPeople.Add(gotRecoveredToday);
            _deaths.Add(gotDeadToday);

            _healthyPeople.Add(
                Math.Max(0,
                         _population.Population - _deaths.Sum() - _recoveredPeople.Sum() - _sickPeople.Sum()));
        }

        private int CalculateRecoveredToday()
        {
            if (_sickPeople.Count < _disease.DaysForRecover)
            {
                return 0;
            }
            else
            {
                return (int)(_sickPeople[DaysSinceOutbreak - _disease.DaysForRecover] * (1d - _disease.DeathChance));
            }
        }

        private int CalculateDeadToday()
        {
            if (_sickPeople.Count < _disease.DaysForRecover)
            {
                return 0;
            }
            else
            {
                return (int)(_sickPeople[DaysSinceOutbreak - _disease.DaysForRecover] * (_disease.DeathChance));
            }
        }

        private int CalculateConvertedFromInfectedToSick()
        {
            if (_infectedPeople.Count < _disease.SymptomsDelayInDays)
            {
                return 0;
            }
            else
            {
                return _infectedPeople[DaysSinceOutbreak - _disease.SymptomsDelayInDays];
            }
        }

        private int CalculateInfectedPeopleInADay()
        {
            var amountOfPopulationWithoutImmunity = (1 - _population.NaturalImmunity) * _population.Population;
            if (amountOfPopulationWithoutImmunity <= _infectedPeople.Sum() + 1)
            {
                return 0;
            }
            else
            {
                var amountOfPeopleWhoCanBeInfected = _population.NaturalImmunity * (_population.Population - _infectedPeople.Sum());
                var infectedToday = GetAmountOfContageousPeopleNow() * _disease.InfectionChance * _population.ChanceOfTwoCitizensMeeting;
                infectedToday += _disease.AmountOfInfectedPeopleComingBackFromHolidayDaily;
                return (int)Math.Min(infectedToday, amountOfPeopleWhoCanBeInfected);
            }
        }
    }
}
