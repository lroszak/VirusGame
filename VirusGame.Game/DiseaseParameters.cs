using System;
using System.Collections.Generic;
using System.Text;

namespace VirusGame.Game
{
    class DiseaseParameters
    {
        double InfectionChance { get; set; }

        int SymptomsDelayInDays { get; set; }
        int DaysForRecover { get; set; }

        public static DiseaseParameters Random()
        {
            return new DiseaseParameters()
            {
                DaysForRecover = new Random().Next(3, 20),
                InfectionChance = (double)new Random().Next(10, 50) / 100d,
                SymptomsDelayInDays = new Random().Next(4, 14)
            };
        }
    }
}
