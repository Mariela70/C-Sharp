using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private readonly ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.raceName = raceName;
            this.numberOfLaps = numberOfLaps;
        }

        public string RaceName 
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid pilot name: { raceName }.");
                }

                raceName = value;
            }

        }

        public int NumberOfLaps 
        {
            get => numberOfLaps; 
            private set 
            {
                if (value<1)
                {
                    throw new ArgumentException($"Invalid lap numbers: { numberOfLaps}.");
                }
                numberOfLaps = value; 
            }
        }

        public bool TookPlace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<IPilot> Pilots => throw new NotImplementedException();

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
           StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The { raceName } race has:");
            sb.AppendLine($"Participants: {string.Join(" ,", pilots)}");
            sb.AppendLine($"Number of laps: { numberOfLaps}");
            sb.AppendLine($"Took place: { TookPlace }");
            return sb.ToString().TrimEnd();
        }
    }
}
