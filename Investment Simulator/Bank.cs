using System;
using System.Collections.Generic;
using System.Text;

namespace Investment_Simulator
{
    public class Bank : Investment
    {

        public Bank(string name) : base(name)
        {
            //Set up all the initial conditions for this stock
            _riskFactor = generate.Next(1, 3);
            value = 1;
            upperGrowth = _riskFactor;
            lowerGrowth = 0.1;
            _description = "This a bank, the value of your money here grows very slowly, it is safe from events that immediately effect stock values";
        }

        public override void CalculateImpact(float valueImpact, float growthImpact)
        {
            //Based off of an event the growth rates will change
            //For a bank there is no 'valueImpact' just growth impact
            //Can grow a maximum of 0.5 times the current growth
            upperGrowth += upperGrowth * (growthImpact / (400 / _riskFactor));
            lowerGrowth += lowerGrowth * (growthImpact / (400 / _riskFactor));
        }
    }
}
