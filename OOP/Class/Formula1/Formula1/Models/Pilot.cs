using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid pilot name: { fullName }.");
                }

                fullName = value;
            }


        }

        public IFormulaOneCar Car
        {
            get => car;
            set
            {

                if (value == null)
                {
                    throw new NullReferenceException($"Pilot car can not be null.");
                }
                car = value;
            }
        }

        public int NumberOfWins { get; set; }

        public bool CanRace => false;

        public void AddCar(IFormulaOneCar car)
        {
           
        }

        public void WinRace()
        {
            NumberOfWins += 1;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {fullName} has {NumberOfWins} wins.");
            return sb.ToString().TrimEnd();
        }
    }
}
