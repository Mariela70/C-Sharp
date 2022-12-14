﻿using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private int size;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Fish name cannot be null or empty.");
                }
                name = value;
            }
        }



        public string Species
        {
            get => species;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Fish species cannot be null or empty.");
                }
                species = value;
            }
        }

        public int Size
        {
            get => size;
            protected set => size = value;

        }

        public decimal Price 
        {
            get => price;
            private set 
            {

                price = value;
                if (price<=0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }
                price = value;

            }
       
         }

        public abstract void Eat();
        
           
        
    }
}
