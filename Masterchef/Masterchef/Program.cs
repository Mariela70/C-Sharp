using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(
                 Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> freshnessLevel = new Stack<int>(
               Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int Dippingsauce = 0;
            int Greensalad = 0;
            int Chocolatecake = 0;
            int Lobster = 0;
          

            while (ingredients.Count != 0 && freshnessLevel.Count != 0)
            {
               
                int currentingredient= ingredients.Peek();
                int currentFreshness = freshnessLevel.Peek();
                int sum = currentingredient * currentFreshness;
                if (currentingredient == 0)
                {
                    ingredients.Dequeue();
                   
                }
                else if (sum == 150)
                {
                    Dippingsauce++;
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                }
                else if(sum ==250)
                {
                    Greensalad++;
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                }
                else if (sum == 300)
                {
                    Chocolatecake++;
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                }
                else if (sum == 400)
                {
                    Lobster++;
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                }
                else
                {
                    freshnessLevel.Pop();
                    currentingredient += 5;
                    ingredients.Dequeue();
                    ingredients.Enqueue(currentingredient);
                }
                

            }
            if(Dippingsauce !=0 && Greensalad !=0 && Chocolatecake !=0 && Lobster !=0)
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine($"You were voted off. Better luck next year.");
            }
            if (ingredients.Sum() > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            if (Chocolatecake > 0)
            {
                Console.WriteLine($"# Chocolate cake --> {Chocolatecake}");
            }
            if (Dippingsauce > 0)
            {
                Console.WriteLine($"# Dipping sauce --> {Dippingsauce}");
            }
            if (Greensalad > 0)
            {
                Console.WriteLine($"# Green salad --> {Greensalad}");
            }
            if (Lobster > 0)
            {
                Console.WriteLine($"# Lobster --> {Lobster}");
            }

        }

    }
}
