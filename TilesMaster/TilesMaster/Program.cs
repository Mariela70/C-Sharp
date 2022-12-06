using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> greyes = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Dictionary<string, int> locations = new Dictionary<string, int>()
            {
                { "Sink", 40},
                { "Oven", 50},
                { "Countertop", 60},
                { "Wall", 70},
            };
            Dictionary<string, int> possibleLocations = new Dictionary<string, int>()
            {
                { "Sink", 0},
                { "Oven", 0},
                { "Countertop", 0},
                { "Wall", 0},
                { "Floor", 0},
            };

            while (whites.Count != 0 && greyes.Count != 0)
            {
                int white = whites.Pop();   
                int grey = greyes.Dequeue();

                if(white == grey)
                {
                    int newTile = white + grey;

                    KeyValuePair<string, int> possibleLocation = locations.FirstOrDefault(x => x.Value == newTile);

                    if(possibleLocation.Key != null)
                    {
                        possibleLocations[possibleLocation.Key]++;
                    }
                    else
                    {
                        possibleLocations["Floor"]++;
                    }
                }
                else
                {
                    whites.Push(white / 2);
                    greyes.Enqueue(grey);
                }
            }
            string whitesLeft = whites.Count == 0 ? "none" : string.Join(", ", whites);
            string greysLeft = greyes.Count == 0 ? "none" : string.Join(", ", greyes);


            Console.WriteLine($"White tiles left: {whitesLeft}");
            Console.WriteLine($"Grey tiles left: {greysLeft}");

            possibleLocations = possibleLocations.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(l=>l.Key, l=> l.Value);

            foreach (var location in possibleLocations)
            {
                if (location.Value != 0)
                {
                    Console.WriteLine($"{location.Key}: {location.Value}");
                }
            }
        }
    }
}
