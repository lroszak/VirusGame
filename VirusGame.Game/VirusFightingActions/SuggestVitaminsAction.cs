namespace VirusGame.Game
{
    internal class SuggestVitaminsAction : VirusFightingAction
    {
        public override string Description => "Tell citizens to take vitamins";

        internal override DiseaseParameters ApplyAction(DiseaseParameters diseaseParameters)
        {
            diseaseParameters.InfectionChance *= 0.6;
            return diseaseParameters;
        }

        internal override PopulationParameters ApplyAction(PopulationParameters populationParameters)
        {
            return populationParameters;
        }
    }
}