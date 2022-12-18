using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private bool submergeMode => false;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, 200, mainWeaponCaliber, speed)
        {
        }
        public override void RepairVessel()
        {
            base.RepairVessel();

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
