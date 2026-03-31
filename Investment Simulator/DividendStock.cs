using System;
using System.Collections.Generic;
using System.Text;

namespace Investment_Simulator
{
    public class DividendStock : Investment
    {
        private float _dividendReturnPercentage;
        private int _dividendFrequency;
        public DividendStock(string name) : base(name)
        {
            //Set up all the initial conditions for this stock
            int[] possibleValues = { 10, 100, 150, 200, 500 };
            _dividendFrequency = generate.Next(1, 3);
            _riskFactor = generate.Next(1, 6);
            _dividendReturnPercentage = _riskFactor * 5 / 100;
            value = possibleValues[generate.Next(possibleValues.Length)];
            upperGrowth = _riskFactor;
            lowerGrowth = -1.0;
            _description = "This is a dividend stock, it doesn't grow a whole lot but it will give you a bit of cash on a regular basis";
        }

        public double DividendPayout(int gameTime)
        {
            //This function is called everyturn for DividendStocks but only pays out when it has to.
            if (gameTime % _dividendFrequency == 0)
            {
                return value * _dividendReturnPercentage;
            }
            else
            {
                return 0;
            }
        }
        public override void CalculateImpact(float valueImpact, float growthImpact)
        {
            //value can increase by 1.5 at most and growth can be increase by 1.25 at most
            value += value * (valueImpact / (1000 / _riskFactor));
            upperGrowth += upperGrowth * (growthImpact / (2000 / _riskFactor));
            lowerGrowth += lowerGrowth * (growthImpact / (2000 / _riskFactor));
        }
    }
}
