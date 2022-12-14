using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders ;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal price;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get => tableNumber; private set => tableNumber = value; }

        public int Capacity 
        {
            get => capacity;
            private set 
            {
                if (value < 0) 
                {
                 throw new ArgumentException("Capacity has to be greater than 0");
                }
            
                capacity = value; 
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get => pricePerPerson; private set => pricePerPerson = value; }

        public bool IsReserved { get => isReserved; private set => isReserved = value; }

        public decimal Price 
        {
            get 
            {
                return pricePerPerson * NumberOfPeople;
            }
        
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            numberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill()
        {
            decimal bill = 0;
            foreach ( var food in foodOrders)
            {
                bill += food.Price;
            }
            foreach (var drink in drinkOrders)
            {
                bill += drink.Price;
            }
            bill += Price;
            return bill;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {pricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
           isReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
