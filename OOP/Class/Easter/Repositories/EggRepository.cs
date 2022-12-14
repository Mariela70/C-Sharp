using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>

    {
        private readonly List<IEgg>eggList;
        public EggRepository()
        {
            this.eggList = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models 
            =>this.eggList;

        public void Add(IEgg model)
        =>this.eggList.Add(model);

        public IEgg FindByName(string name)
        =>this.eggList.FirstOrDefault(e => e.Name == name);

        public bool Remove(IEgg model)
        =>this.eggList.Remove(model);
    }
}
