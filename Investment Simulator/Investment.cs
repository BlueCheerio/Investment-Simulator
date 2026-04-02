using System;
using System.Collections.Generic;
using System.Text;

namespace Investment_Simulator
{
    public class Investment
    {
        private string _name;
        private int _numberOfStocks;
        protected string _description;
        protected int _riskFactor;
        protected double value;
        private double _previousValue;
        protected double upperGrowth;
        protected double lowerGrowth;
        protected double growth; //We will want to display this under the value of each stock otherwise we don't need it
        protected Random generate = new Random();
        public Investment(string name)
        {
            _name = name;
            _numberOfStocks = 0;
        }

        public void CalculateGrowth()
        {
            //Generate a random percentage that we want the stock to increase / decrease by
            growth = generate.NextDouble() * (upperGrowth - lowerGrowth) + lowerGrowth;
            value = value * (1 + growth / 100);
        }
        public virtual void CalculateImpact(float valueImpact, float growthImpact)
        {

        }

        //4 getters and a setter for investing money
        public string GetName()
        {
            return _name;
        }
        public string GetDescription()
        {
            return _description;
        }
        public double GetValue()
        {
            return value;
        }
        public double GetPreviousValue()
        {
            return _previousValue;
        }
        public double GetGrowth()
        {
            return growth;
        }
        public int GetNumberOfStocks()
        {
            return _numberOfStocks;
        }
        public void SetNumberOfStocks(int numberofStocks)
        {
            _numberOfStocks = numberofStocks;
        }
        public void SetPreviousValue(double Value)
        {
            _previousValue = Value;
        }

    }
}
