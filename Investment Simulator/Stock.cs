using System;
using System.Collections.Generic;
using System.Text;

namespace Investment_Simulator
{
    public class Stock : Investment
    {
        public Stock(string name) : base(name)
        {
            //Set up all the initial conditions for this stock
            double[] possibleValues = { 0.01, 0.05, 0.1, 0.5, 1, 5 };
            _riskFactor = generate.Next(3, 31);
            value = possibleValues[generate.Next(possibleValues.Length)];
            upperGrowth = _riskFactor;
            lowerGrowth = _riskFactor * -1 / 1.2; //This way the stocks should (overall) grow
            _description = "This is your basic stock, it is mildy risky but in general the value grows";
        }

        public override void CalculateImpact(float valueImpact, float growthImpact)
        {
            //value can increase by 3 times at most but growth can be tripled
            value += value * (valueImpact / (1800 / _riskFactor));
            upperGrowth += upperGrowth * (growthImpact / (1500 / _riskFactor));
            lowerGrowth += lowerGrowth * (growthImpact / (1500 / _riskFactor));
        }
    }
}
