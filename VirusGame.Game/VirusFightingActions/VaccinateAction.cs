using System;
using System.Collections.Generic;
using System.Text;

namespace VirusGame.Game.VirusFightingActions
{
    class VaccinateAction : VirusFightingAction
    {
        public override string Description => "Vaccinate Citizens";

        internal override DiseaseParameters ApplyAction(DiseaseParameters diseaseParameters)
        {
            return diseaseParameters;
        }

        internal override PopulationParameters ApplyAction(PopulationParameters populationParameters)
        {
            populationParameters.NaturalImmunity *= 1.5;
            populationParameters.NaturalImmunity = Math.Max(1, populationParameters.NaturalImmunity);

            return populationParameters;
        }
    }
}
