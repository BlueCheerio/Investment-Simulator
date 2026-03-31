using System;
using System.Collections.Generic;
using System.Text;

namespace Investment_Simulator
{
    public class ETF : Investment
    {
        public ETF(string name) : base(name)
        {
            //Set up all the initial conditions for this stock
            double[] possibleValues = { 20, 40, 50, 100, 200, 300, 400, 500, 600 };
            _riskFactor = generate.Next(5, 10);
            value = possibleValues[generate.Next(possibleValues.Length)];
            upperGrowth = _riskFactor;
            lowerGrowth = _riskFactor * -1 / 2;
            _description = "This is an ETF or blue chip stock, this is a company that has proven its worth and is continually growing";
        }

        public override void CalculateImpact(float valueImpact, float growthImpact)
        {
            //value can increase by 2 times at most and growth can be doubled as well
            value += value * (valueImpact / (1000 / _riskFactor));
            upperGrowth += upperGrowth * (growthImpact / (1000 / _riskFactor));
            lowerGrowth += lowerGrowth * (growthImpact / (1000 / _riskFactor));
        }
    }
}
