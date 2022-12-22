using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Ski ski) 
        {
            if (Count<Capacity)
            {
                data.Add(ski);
            }
           
        
        }
        public bool Remove(string manufacturer, string model) 
        {
            Ski ski = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski == null) 
            {
             return false;
            }
            return data.Remove(ski);

        }
        public Ski GetNewestSki() 
        {
         return data.OrderByDescending(x => x.Year).FirstOrDefault();
        
        }
        public Ski GetSki(string manufacturer, string model) 
        {
         return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        
        }
        public string GetStatistics() 
        {
         StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}");

            foreach (Ski ski in data) 
            {
                sb.AppendLine(ski.ToString());
            
            }
            return sb.ToString().TrimEnd();

        }

    }
}
