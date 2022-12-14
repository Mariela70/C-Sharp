using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
 
        private double armorThickness;
        private ICaptain captain;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;

        public Vessel(string name, double armorThickness, double mainWeaponCaliber, double speed)
        {
            this.name = name;
            this.armorThickness = armorThickness;
            this.mainWeaponCaliber = mainWeaponCaliber;
            this.speed = speed;
            this.targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Vessel name cannot be null or empty.");
                }
                name = value;
            }


        }

        public ICaptain Captain
        {
            get => captain;
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                captain = value; 
            } 
                
                
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; private set; }

        public double Speed { get; private set; }

        public ICollection<string> Targets => this.targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }
            armorThickness -= mainWeaponCaliber;
            if (mainWeaponCaliber<0)
            {
                mainWeaponCaliber = 0;
            }
            target.Attack(target);
        }

        public virtual void RepairVessel()
        {
           
        }
        public  override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(name);
            return sb.ToString().TrimEnd();
        }
    }
}
