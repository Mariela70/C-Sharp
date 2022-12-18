using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronautRepo;
        private readonly IRepository<IPlanet> planetRepo;
        private readonly IMission mission;
        private int exploredPlanets;

        public Controller()
        {
            this.astronautRepo = new AstronautRepository();
            this.planetRepo = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
           IAstronaut astronaut;
            if (type == nameof(Biologist)) 
            {
             astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            this.astronautRepo.Add(astronaut);
            string result = string.Format(OutputMessages.AstronautAdded, type, astronautName);
            return result;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            this.planetRepo.Add(planet);
            string result = string.Format(OutputMessages.PlanetAdded, planetName);
            return result;

        }

        public string ExplorePlanet(string planetName)
        {
            var astronauts = this.astronautRepo.Models.Where(x => x.Oxygen > 60).ToList();

            if (!astronauts.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            exploredPlanets++;
            var planet = this.planetRepo.FindByName(planetName);
            this.mission.Explore(planet, astronauts);
            int deadAstr = 0;
            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    deadAstr++;
                }
            }
            string result = string.Format(OutputMessages.PlanetExplored, planetName, deadAstr);
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronautRepo.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                string itemsInfo = astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none";
                sb.AppendLine($"Bag items: {itemsInfo}");
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
           IAstronaut astronaut=this.astronautRepo.FindByName(astronautName);
            if (astronaut == null) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            
            }
            this.astronautRepo.Remove(astronaut);
            string result =string.Format(OutputMessages.AstronautRetired, astronautName);
            return result;
        }
    }
}
