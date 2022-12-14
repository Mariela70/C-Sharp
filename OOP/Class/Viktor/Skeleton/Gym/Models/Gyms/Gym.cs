using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private List<IEquipment> equipmentList;
        private List<IAthlete> athleteList;
        private string name;
        private int capacity;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.equipmentList = new List<IEquipment>();
            this.athleteList = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Gym name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity { get => capacity; private set => capacity = value; }

        public double EquipmentWeight
        {
            get { return this.Equipment.Select(e => e.Weight).Sum(); }
        }


        public ICollection<IEquipment> Equipment => this.equipmentList;

        public ICollection<IAthlete> Athletes => this.athleteList;

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count >=Capacity)
            {
                throw new InvalidOperationException($"Not enough space in the gym.");
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var atlete in Athletes) 
            {
             atlete.Exercise();
            
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {this.GetType().Name}:");
            string athletes;
            if(Athletes.Count > 0) 
            {
             athletes = string.Join(",", Athletes.Select(x=>x.FullName));
            
            }
            else
            {
                athletes = "No athletes";
            }
            sb.AppendLine($"Athletes: {athletes}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
