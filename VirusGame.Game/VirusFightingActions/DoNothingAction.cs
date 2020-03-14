namespace VirusGame.Game
{
    internal class DoNothingAction : VirusFightingAction
    {
        public override string Description => "Do nothing";

        internal override DiseaseParameters ApplyAction(DiseaseParameters diseaseParameters)
        {
            return diseaseParameters;
        }

        internal override PopulationParameters ApplyAction(PopulationParameters populationParameters)
        {
            return populationParameters;
        }
    }
}