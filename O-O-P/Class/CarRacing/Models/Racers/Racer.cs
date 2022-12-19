using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        ICar car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }

                username = value;
            }

        }

        public string RacingBehavior
        {
            get => racingBehavior;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }

                racingBehavior = value;
            }

        }

        public int DrivingExperience 
        {
            get => drivingExperience; 
            set 
            {
                if (value<0 || value >100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }
            
                drivingExperience = value; 
            
            }
        }

        public ICar Car 
        {
            get => car; 
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }
                car = value; 
            
            }
        }

        public bool IsAvailable() 
        {

            if (this.car.FuelAvailable>=this.car.FuelConsumptionPerRace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public virtual void Race()
        {
            this.car.Drive();
        }
    }
}
