using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ski_Resorts
{
    class Ski_Resort
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private int _highest_peak;

        public int _Highest_Peak
        {
            get { return _highest_peak; }
            set { _highest_peak = value; }
        }

        private int _km;

        public int Km
        {
            get { return _km; }
            set { _km = value; }
        }

        private int _the_longest_slope;

        public int The_Longest_Slope
        {
            get { return _the_longest_slope; }
            set { _the_longest_slope = value; }
        }

        private int _ski_lifts;

        public int Ski_Lifts
        {
            get { return _ski_lifts; }
            set { _ski_lifts = value; }
        }

        private int _snowparks;

        public int Snowparks
        {
            get { return _snowparks; }
            set { _snowparks = value; }
        }

        private int _rink;

        public int Rink
        {
            get { return _rink; }
            set { _rink = value; }
        }

        private int _skipass;

        public int Skipass
        {
            get { return _skipass; }
            set { _skipass = value; }
        }
    }
}
