using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;
        private int horsePower;

        protected Car(string make, string model, string vIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vin;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => make;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }

                make = value;
            }

        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }

                model = value;
            }


        }


        public string VIN
        {
            get => vin;
            private set
            {
                if (value.Length!=17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                vin = value;

            }


        }

        public int HorsePower 
        {
            get => horsePower;
             set 
            {
                if (value< 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }
                horsePower = value;
            } 
        }

        public double FuelAvailable 
        {
            get => fuelAvailable;
            private set 
            {
                if (fuelAvailable < 0)
                {
                    fuelAvailable = 0;
                }
                fuelAvailable = value;
            }
               
        }

        public double FuelConsumptionPerRace 
        {
            get => fuelConsumptionPerRace; 
            private set 
            {
                if (value< 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
                fuelConsumptionPerRace = value;
            
            }
        }

        public virtual void Drive()
        {
            fuelAvailable -= fuelConsumptionPerRace;
        }
    }
}
