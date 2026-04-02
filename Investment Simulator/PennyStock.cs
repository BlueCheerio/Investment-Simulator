using System;
using System.Collections.Generic;
using System.Text;

namespace Investment_Simulator
{
    public class PennyStock : Investment
    {
        public PennyStock(string name) : base(name)
        {
            //Set up all the initial conditions for this stock
            double[] possibleValues = { 0.01, 0.05, 0.1, 0.5, 1, 5 };
            _riskFactor = generate.Next(100, 201);
            value = possibleValues[generate.Next(possibleValues.Length)];
            //Penny Stocks don't really ever change value so the growth isn't much, it's dependent on events to change value or growth
            upperGrowth = _riskFactor / 100;
            lowerGrowth = _riskFactor * -1 / 100;
            _description = "This is a Penny Stock, each stock isn't worth much and they only grow by fractions of a cent but events can effect their values wildly";
        }

        public override void CalculateImpact(float valueImpact, float growthImpact)
        {
            //value can increase by 50 times at most and growth can be doubled as well
            value += value * (valueImpact / (400 / _riskFactor));
            upperGrowth += upperGrowth * (growthImpact / (20000 / _riskFactor));
            lowerGrowth += lowerGrowth * (growthImpact / (20000 / _riskFactor));
        }
    }
}
