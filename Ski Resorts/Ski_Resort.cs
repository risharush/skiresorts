using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ski_Resorts
{
    [Serializable]
    public class Ski_Resort
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

        public int Highest_Peak
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

        private int _longest_slope;

        public int Longest_Slope
        {
            get { return _longest_slope; }
            set { _longest_slope = value; }
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

        private string _photo;

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        private List<Hotel> _hotels;

        public List<Hotel> Hotels
        {
            get { return _hotels; }
            set { _hotels = value; }
        }



        public Ski_Resort(string name, string country, int highest_peak, int km, int longestslope, int ski_lifts, int snowparks, int rink, int skipass, string photo, List<Hotel> hotels)
        {
            Name = name;
            Country = country;
            Highest_Peak = highest_peak;
            Km = km;
            Longest_Slope = longestslope;
            Ski_Lifts = ski_lifts;
            Snowparks = snowparks;
            Rink = rink;
            Skipass = skipass;
            Photo = photo;
            Hotels = hotels;
        }

        public Ski_Resort()
        {

        }

        public string Show()
        {
            return string.Format(Name + ' ' + Country + ' ' + Highest_Peak + ' ' + Km + ' ' + Longest_Slope + ' ' + Ski_Lifts + ' ' + Snowparks + ' ' + Rink + ' ' + Skipass);
        }
    }
}
