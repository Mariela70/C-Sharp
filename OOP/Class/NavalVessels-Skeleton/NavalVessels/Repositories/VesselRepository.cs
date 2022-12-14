using NavalVessels.Models;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<Vessel>
    {
        private List<Vessel> vessels;
        public VesselRepository()
        {
            this.vessels = new List<Vessel>();
        }
        public IReadOnlyCollection<Vessel> Models => this.vessels;

        public void Add(Vessel model)
        {
            vessels.Add(model);
        }

        public Vessel FindByName(string name)
        {
            return this.vessels.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(Vessel model)
        {
            return vessels.Remove(model);
        }
    }
}
