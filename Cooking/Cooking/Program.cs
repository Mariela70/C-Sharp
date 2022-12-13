using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] InputLiquid = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] Inputingredient = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int>liquids = new Stack<int>(InputLiquid);
            Queue<int> ingredients = new Queue<int>(Inputingredient);
            int Bread = 25;
            int Cake = 50;
            int Pastry = 75;
            int FruitPie = 100;
           
           


            while (liquids.Count ==0 && ingredients.Count ==0)
            {
                int liguid = liquids.Peek();
                int ingredien = ingredients.Peek();
                int sum = liguid + ingredien;
                string Produkt = string.Empty;
                if (sum == Bread)
                {
                    liquids.Pop();
                    ingredients.Dequeue();
                }
                if (sum == Cake)
                {
                    liquids.Pop();
                    ingredients.Dequeue();
                }
                if (sum == Pastry)
                {
                    liquids.Pop();
                    ingredients.Dequeue();
                }
                if (sum == FruitPie)
                {
                    liquids.Pop();
                    ingredients.Dequeue();
                }
                else
                {
                    liquids.Pop();
                    int value = ingredients.Peek() + 3;
                    ingredients.Enqueue(value);

                }

            }
            if (ingredients.Count ==0 && liquids.Count == 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count>0)
            {
                Console.WriteLine($"Liquids left: {string.Join(" ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Count>0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(" ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bread: {amount}");
            sb.AppendLine($"Cake: {amount}");
            sb.AppendLine($"Fruit Pie: {amount}");
            sb.Append($"Pastry: {amount}");
        }
    }
}
