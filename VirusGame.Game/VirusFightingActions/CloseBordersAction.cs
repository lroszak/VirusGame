namespace VirusGame.Game
{
    internal class CloseBordersAction : VirusFightingAction
    {
        public override string Description => "Close borders";

        internal override DiseaseParameters ApplyAction(DiseaseParameters diseaseParameters)
        {
            diseaseParameters.AmountOfInfectedPeopleComingBackFromHolidayDaily = 0;

            return diseaseParameters;
        }

        internal override PopulationParameters ApplyAction(PopulationParameters populationParameters)
        {
            return populationParameters;
        }
    }
}