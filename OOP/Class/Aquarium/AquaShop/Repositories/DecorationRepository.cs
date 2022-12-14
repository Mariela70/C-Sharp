using AquaShop.Models.Decorations;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<Decoration>
    {
        private readonly List<Decoration>decorations;
        public DecorationRepository()
        {
            this.decorations = new List<Decoration>();
        }
        public IReadOnlyCollection<Decoration> Models => this.decorations.AsReadOnly();

        public void Add(Decoration model) =>this.decorations.Add(model);


        public Decoration FindByType(string type) => this.decorations.FirstOrDefault(x => x.GetType().Name == type);
        

        public bool Remove(Decoration model) => this.decorations.Remove(model); 
        
    }
}
