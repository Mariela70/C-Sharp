using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Bag : IBag
    {
        private int capacity;
        private int load;
        private readonly List<int> items;

        public Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<int>();
        }

        public int Capacity { get => capacity; set => capacity = value; }

        public int Load => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.Items;

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
