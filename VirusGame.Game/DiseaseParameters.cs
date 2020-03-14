using System;
using System.Collections.Generic;
using System.Text;

namespace VirusGame.Game
{
    struct DiseaseParameters
    {
        public double InfectionChance { get; set; }
        public double DeathChance { get; set; }

        public int SymptomsDelayInDays { get; set; }
        public int DaysForRecover { get; set; }
        public int InitialAmountOfSickPeople { get; private set; }

        public static DiseaseParameters Random()
        {
            return new DiseaseParameters()
            {
                DaysForRecover = new Random().Next(3, 10),
                InfectionChance = (double)new Random().Next(25, 70) / 100d,
                DeathChance= (double)new Random().Next(5, 100) / 1000d,
                SymptomsDelayInDays = new Random().Next(4, 14),
                InitialAmountOfSickPeople = new Random().Next(1, 1000),
            };
        }
    }
}
