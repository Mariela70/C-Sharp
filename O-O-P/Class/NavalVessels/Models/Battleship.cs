using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private bool sonarMode => false;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, 300, mainWeaponCaliber, speed)
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
