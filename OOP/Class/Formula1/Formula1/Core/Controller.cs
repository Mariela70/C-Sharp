using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            throw new NotImplementedException();
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            throw new NotImplementedException();
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            FormulaOneCar formulaOneCar = (FormulaOneCar)carRepository.FindByName(model);
            if (model == null)
            {
               
            }
            if (type == "Ferrari")
            {
                
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }
            else
            {
                this.carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
            }
            if (type == "Williams") 
            {
                this.carRepository.Add(new Williams(model, horsepower, engineDisplacement));
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }
            else
            {
                this.carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
            }
            else 
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }
            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            PilotRepository pilotRepository = pilotRepository.FindByName(fullName());

            if (fullName != fullName)
            {
                throw new InvalidOperationException($"Pilot { fullName} is already created.");
            }
            else
            {
                this.pilotRepository.Add();
                return ($"Pilot { fullName } is created.");
            }
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceName == )
            {

            }
        }

        public string PilotReport()
        {
            throw new NotImplementedException();
        }

        public string RaceReport()
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
