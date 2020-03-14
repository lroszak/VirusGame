namespace VirusGame.Game
{
    public class GameState
    {
        public int DaysSinceOutbreak { get; internal set; }

        public int CountryPopulation { get; internal set; }
        public int SickPeopleCount { get; internal set; }
        public int CuredPeopleCount { get; internal set; }
        public object DeadPeopleCount { get; set; }
    }
}