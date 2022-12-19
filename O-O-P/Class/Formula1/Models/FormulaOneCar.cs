using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model 
        {
            get => model;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid car model: { model }.");
                }
                
                
            
                model = value;
            }
        }

        public int Horsepower 
        {
            get => horsepower;
            private set 
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException($"Invalid car horsepower: { horsepower }.");
                }
            
                horsepower = value; 
            }
        }

        public double EngineDisplacement 
        {
            get => engineDisplacement;
            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException($"Invalid car engine displacement: { engineDisplacement }.");
                }

                engineDisplacement = value;
            }


        }


        public double RaceScoreCalculator(int laps)
        {
           return engineDisplacement / horsepower * laps;

        }
    }
}
