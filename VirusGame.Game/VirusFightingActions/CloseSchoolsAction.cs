namespace VirusGame.Game
{
    internal class CloseSchoolsAction : VirusFightingAction
    {
        public override string Description => "Close schools";
        internal override DiseaseParameters ApplyAction(DiseaseParameters diseaseParameters)
        {
            return diseaseParameters;
        }

        internal override PopulationParameters ApplyAction(PopulationParameters populationParameters)
        {
            populationParameters.ChanceOfTwoCitizensMeeting *= 0.9;

            return populationParameters;
        }
    }
}