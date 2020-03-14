using System;

namespace VirusGame.Game
{
    internal class InventMedicineAction : VirusFightingAction
    {
        private double _medicineAccuracy = new Random().NextDouble();

        public override string Description => "Give out experimental Medicine Action";

        internal override DiseaseParameters ApplyAction(DiseaseParameters diseaseParameters)
        {
            diseaseParameters.DeathChance *= _medicineAccuracy;
            return diseaseParameters;
        }

        internal override PopulationParameters ApplyAction(PopulationParameters populationParameters)
        {
            return populationParameters;
        }
    }
}