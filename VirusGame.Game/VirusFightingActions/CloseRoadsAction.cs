namespace VirusGame.Game
{
    internal class CloseRoadsAction : VirusFightingAction
    {
        public override string Description => "Close roads";

        internal override DiseaseParameters ApplyAction(DiseaseParameters diseaseParameters)
        {
            return diseaseParameters;
        }

        internal override PopulationParameters ApplyAction(PopulationParameters populationParameters)
        {
            populationParameters.ChanceOfTwoCitizensMeeting *= 0.6;

            return populationParameters;
        }
    }
}