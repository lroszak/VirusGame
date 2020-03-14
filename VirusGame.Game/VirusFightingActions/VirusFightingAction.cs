namespace VirusGame.Game
{
    public abstract class VirusFightingAction
    {
        public abstract string Description { get; }

        internal abstract DiseaseParameters ApplyAction(DiseaseParameters diseaseParameters);
        internal abstract PopulationParameters ApplyAction(PopulationParameters populationParameters);
    }
}