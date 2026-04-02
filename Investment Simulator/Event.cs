using System;
using System.Collections.Generic;
using System.Text;

namespace Investment_Simulator
{
    public class Event
    {
        private string _name;
        private Random _generate = new Random();
        private float _valueImpact;
        private float _growthImpact;
        private bool _global;
        private bool _warning;
        private int _impactedCompany;
        private int _certainty;
        public Event(string name, bool good)
        {
            _name = name;
            //Set our Impact floats
            if (good)
            {
                _valueImpact = _generate.Next(1, 101);
                _growthImpact = _generate.Next(1, 101);
            }
            else if (!good)
            {
                _valueImpact = _generate.Next(-100, 1);
                _growthImpact = _generate.Next(-100, 1);
            }
            //Set our global factor (20% chance that it is global)
            int number = _generate.Next(10);
            if (number > 7) _global = true;
            else _global = false;
            if (!_global)
            {
                _impactedCompany = _generate.Next(0, 9);
            }
            //Set our warning factor (50% chance to get a warning)
            number = _generate.Next(2);
            if (number != 0) _warning = true;
            else _warning = false;
            //Set our time wait factor
            number = _generate.Next(3);
            //Set our certainty factor (chance that it will actually happen, always at least %50 chance of happening)
            _certainty = _generate.Next(50, 101);
        }

        //7 getters to return literally any variable in this class
        public string GetName()
        {
            return _name;
        }
        public float GetImpact()
        {
            return _valueImpact;
        }
        public float GetGrowth()
        {
            return _growthImpact;
        }
        public bool GetGlobal()
        {
            return _global;
        }
        public bool GetWarning()
        {
            return _warning;
        }
        public int GetCompanyImpacted()
        {
            return _impactedCompany;
        }
        public int GetCertainty()
        {
            return _certainty;
        }
    }
}
