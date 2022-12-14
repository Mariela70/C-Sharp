using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, 60, numberOfMedals)
        {
        }
        public override void Exercise()
        {
            Stamina += 100;
            if (Stamina > 100)
            {
                Stamina = 10; ;
                throw new ArgumentException($"Stamina cannot exceed 100 points.");
            }
        }

    }
}
