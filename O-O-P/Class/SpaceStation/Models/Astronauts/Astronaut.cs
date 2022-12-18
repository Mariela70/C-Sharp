using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut

    {
        private string name;
        private double oxygen;
        private bool canBreath;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.name = name;
            this.oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name 
        {
            get => name;
            private set 
            { 
                if (string.IsNullOrEmpty(value)) 
                {
                 throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
            
                name = value; 
            }
        }

        public double Oxygen 
        {
            get => oxygen;
            protected set 
            {
                if (value < 0)
                {
                    throw new ArithmeticException("Cannot create Astronaut with negative oxygen!");
                }
                oxygen = value; 
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag { get; }

        public  virtual void Breath()
        {
            if (this.Oxygen -10 < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 10;
            }
        }
    }
}
