namespace VirusGame.Game
{
    internal class CloseShopsAction : VirusFightingAction
    {
        public override string Description => "Close shops.";

        internal override DiseaseParameters ApplyAction(DiseaseParameters diseaseParameters)
        {
            return diseaseParameters;
        }

        internal override PopulationParameters ApplyAction(PopulationParameters populationParameters)
        {
            populationParameters.ChanceOfTwoCitizensMeeting *= 0.7;

            return populationParameters; 
        }
    }
}