using System;
using System.Collections.Generic;
using System.Text;

namespace Investment_Simulator
{
    public class Crypto : Investment
    {
        public Crypto(string name) : base(name)
        {
            //Set up all the initial conditions for this stock
            double[] possibleValues = { 0.1, 1, 5, 10, 100, 1000, 10000, 100000 };
            _riskFactor = generate.Next(10, 101);
            value = possibleValues[generate.Next(possibleValues.Length)];
            upperGrowth = _riskFactor;
            lowerGrowth = _riskFactor * -1;
            _description = "This is a crypto stock, it's values fluctuate wildly and are often unpredictable";
        }

        public override void CalculateImpact(float valueImpact, float growthImpact)
        {
            //Value can be multiplied by 10 at most and growth is multiplied by 10 at most
            value += value * (valueImpact / (1000 / _riskFactor));
            upperGrowth += upperGrowth * (growthImpact / (1000 / _riskFactor));
            lowerGrowth += lowerGrowth * (growthImpact / (1000 / _riskFactor));
        }
    }
}
