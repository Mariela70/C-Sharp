using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunies;
        private readonly IRepository<IEgg> eggs;
        private readonly IWorkshop workshop;

        public Controller()
        {
            this.bunies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny)) 
            {
              bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }
            this.bunies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunies.FindByName(bunnyName);

            if (bunny == null) 
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            IDye dye = new Dye(power);
            bunny.Dyes.Add(dye);
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);
            return $"Successfully added egg: { eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> bunnyList = this.bunies.Models
                .Where(x => x.Energy>=50)
                .OrderByDescending(x => x.Energy)
                .ToList();
            if (bunnyList.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }
            IEgg egg = this.eggs.FindByName(eggName);

            foreach (var bunny in bunnyList)
            {
                this.workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunies.Remove(bunny);
                }
                if (egg.IsDone())
                {
                    break;
                }
            }
            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.eggs.Models.Count(x=> x.IsDone())} eggs are done!");
            sb.AppendLine($"Bunnies info:");

            foreach (var bunny in this.bunies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
