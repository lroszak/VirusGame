﻿using System;

namespace VirusGame.Game
{
    struct PopulationParameters
    {
        public int Population { get; set; }
        public double NaturalImmunity { get; set; }
        public double ChanceOfTwoCitizensMeeting { get; set; }

        internal static PopulationParameters Random()
        {
            return new PopulationParameters()
            {
                Population = new Random().Next(4_000_000, 1_000_000_000),
                NaturalImmunity = (double)new Random().Next(0, 70) / 100d,
                ChanceOfTwoCitizensMeeting = (double)new Random().Next(10, 60) / 100d
            };
        }
    }
}