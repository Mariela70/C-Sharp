using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private List<IAquarium> aquariums;
        public Controller()
        {
            decorationRepository = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
           else if (aquariumType == "SaltwaterAquarium")
            {
               this.aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else 
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                this.decorationRepository.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                this.decorationRepository.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(SaltwaterFish) && fishType != nameof(FreshwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            IFish fish;
            IAquarium desiredAquarim = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if(fishType == nameof(SaltwaterFish)) 
            {
             fish = new SaltwaterFish(fishName, fishSpecies, price);
                if (desiredAquarim.GetType().Name != nameof(SaltwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                if (desiredAquarim.GetType().Name != nameof(FreshwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            desiredAquarim.AddFish(fish);
            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal sumOfDecoration = aquarium.Decorations.Sum(x=>x.Price);
            decimal sumOfFishes = aquarium.Fish.Sum(x=>x.Price);
            decimal totalPrise  = sumOfDecoration + sumOfFishes;
            return String.Format(OutputMessages.AquariumValue, aquariumName, totalPrise);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
           IDecoration decoration= decorationRepository.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            this.decorationRepository.Remove(decoration);

            
            return $"Successfully added { decorationType} to { aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAquarium aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
