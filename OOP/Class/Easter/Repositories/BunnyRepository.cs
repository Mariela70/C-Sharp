using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunnyList;
        public BunnyRepository()
        {
            this.bunnyList = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models 
            =>this.bunnyList;

        public void Add(IBunny model)
        =>this.bunnyList.Add(model);

        public IBunny FindByName(string name)
        =>this.bunnyList.FirstOrDefault(x => x.Name == name);

        public bool Remove(IBunny model)
        =>this.bunnyList.Remove(model);
    }
}
