using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ski_Resorts
{
    public class Hotel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _people;

        public int People
        {
            get { return _people; }
            set { _people = value; }
        }

        private int _km;

        public int Km
        {
            get { return _km; }
            set { _km = value; }
        }

        private int _wifi;

        public int Wifi
        {
            get { return _wifi; }
            set { _wifi = value; }
        }

        private int _sauna;

        public int Sauna
        {
            get { return _sauna; }
            set { _sauna = value; }
        }

        private string _photo1;

        public string Photo1
        {
            get { return _photo1; }
            set { _photo1 = value; }
        }

        private string _photo2;

        public string Photo2
        {
            get { return _photo2; }
            set { _photo2 = value; }
        }

        public Hotel(string name, int price, int people, int km, int wifi, int sauna, string photo1, string photo2)
        {
            Name = name;
            Price = price;
            People = people;
            Km = km;
            Wifi = wifi;
            Sauna = sauna;
            Photo1 = photo1;
            Photo2 = photo2;
        }

        public Hotel()
        {

        }
    }
}
