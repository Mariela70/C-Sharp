using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            
            if (!racerOne.IsAvailable() & !racerTwo.IsAvailable())
            {
                return $"Race cannot be completed because both racers are not available!";
            }
            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            racerOne.Race();
            racerTwo.Race();

            double firstRacerWin = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            if (racerOne.RacingBehavior == "strict")
            {
                firstRacerWin *= 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                firstRacerWin *= 1.1;
            }
            double secondRacerWin = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
            if (racerTwo.RacingBehavior == "strict")
            {
                secondRacerWin *= 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                secondRacerWin *= 1.1;
            }
            IRacer winner;
            if (firstRacerWin > secondRacerWin)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }
        }

       
    }
}
