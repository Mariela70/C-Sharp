using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private List<string> vessels;

        public Captain(string fullName, List<string> vessels)
        {
            this.fullName = fullName;
            this.vessels = new List<string>();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Captain full name cannot be null or empty string.");
                }
                fullName = value;
            }
        }

        public int CombatExperience 
        {
            get => combatExperience; 
            private set => combatExperience = 0; 
        
        }

        public ICollection<IVessel> Vessels => this.Vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException($"Null vessel cannot be added to the captain.");
            }
            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
