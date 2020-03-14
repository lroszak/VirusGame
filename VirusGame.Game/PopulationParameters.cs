using System;

namespace VirusGame.Game
{
    internal class PopulationParameters
    {
        int Poupulation { get; set; }
        double NaturalImmunity { get; set; }
        double ChanceOfTwoCitizensMeeting { get; set; }

        internal static PopulationParameters Random()
        {
            return new PopulationParameters()
            {
                Poupulation = new Random().Next(4_000_000, 1_000_000_000),
                NaturalImmunity = (double)new Random().Next(0, 70) / 100d,
                ChanceOfTwoCitizensMeeting = (double)new Random().Next(1, 20) / 100d
            };
        }
    }
}