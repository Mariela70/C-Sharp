using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(
                Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(
               Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int claimedItems = 0;

            while(firstBox.Count != 0 && secondBox.Count != 0)
            {
                int currentFirstBox = firstBox.Peek();
                int currentSecondBox = secondBox.Peek();
                int sum = currentFirstBox + currentSecondBox;

                if(sum%2==0)
                {
                    claimedItems+=sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    secondBox.Pop();
                    firstBox.Enqueue(currentSecondBox);
                }
            }
            if(firstBox.Count == 0)
            {
                Console.WriteLine($"First lootbox is empty");
            }
            else if(secondBox.Count == 0)
            {
                Console.WriteLine($"Second lootbox is empty");
            }
            if(claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
