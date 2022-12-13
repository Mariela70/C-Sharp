using System;
using System.Collections.Generic;
using System.Linq;

namespace Barista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cofee = new Queue<int>(
               Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Stack<int> milk = new Stack<int>(
               Console.ReadLine().Split(", ").Select(int.Parse).ToArray());


            int cortado = 0;
            int espresso = 0;
            int capuccino = 0;
            int americano = 0;
            int latte = 0;

            while(cofee.Count != 0 && milk.Count != 0)
            {
              int currentCaffe = cofee.Peek();
             int  currentMilk = milk.Peek();
                int combined = currentCaffe + currentMilk;
                if(combined == 50)
                {
                    cortado++;
                    cofee.Dequeue();
                    milk.Pop();
                }
                else if (combined ==75)
                {
                    espresso++;
                    cofee.Dequeue();
                    milk.Pop();
                }
                else if (combined ==100)
                {
                    capuccino++;
                    cofee.Dequeue();
                    milk.Pop();
                }
                else if (combined == 150)
                {
                    americano++;
                    cofee.Dequeue();
                    milk.Pop();
                }
                else if (combined ==200)
                {
                    latte++;
                    cofee.Dequeue();
                    milk.Pop();
                }
                else
                {
                    cofee.Dequeue();
                    milk.Push(currentMilk-=5);
                }
            }
            if(cofee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine($"Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine($"Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            if(cofee.Count==0)
            {
                Console.WriteLine($"Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffe left: {string.Join(", ", cofee)}");
            }
            if (milk.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
        }
    }
}
