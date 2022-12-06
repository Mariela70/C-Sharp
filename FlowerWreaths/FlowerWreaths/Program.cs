using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(
                Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(
                Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            int wreaths = 0;
            int flowers = 0;

            while(lilies.Count > 0 && roses.Count > 0)
            {
                int lili = lilies.Pop();
                int rose = roses.Dequeue();
                while(true)
                {
                int sum = lili + rose;

                if(sum == 15)
                {
                    wreaths++;
                        break;
                }
                    else if(sum < 15)
                {
                    flowers += sum;
                        break;
                }
                    else
                {
                        lili -= 2;
                }
                }
                
            }
            wreaths += flowers / 15;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
