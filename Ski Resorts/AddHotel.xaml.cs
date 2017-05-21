using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ski_Resorts
{
    /// <summary>
    /// Логика взаимодействия для AddHotel.xaml
    /// </summary>
    public partial class AddHotel : Window
    {
        public ListOfResorts lr = new ListOfResorts();
        public List<Hotel> hotels = new List<Hotel>();
        public Ski_Resort ski3 = new Ski_Resort();

        public AddHotel()
        {
            InitializeComponent();

            lr.Res = new List<Ski_Resort>();
            if (File.Exists("../../allresorts.xml"))
            {

                lr = Serialization.Deserialize(lr);

            }
            foreach (var item in lr.Res)
            {
                foreach (var h in item.Hotels)
                {
                    hotels.Add(h);
                }
            }

            
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lr.Res)
            {
                if (ski3.Name == item.Name)
                {
                    int wifi = 0;
                    if (checkBoxWifi.IsChecked ?? false)
                    {
                        wifi = 1;
                    }

                    int sauna = 0;
                    if (checkBoxWifi.IsChecked ?? false)
                    {
                        sauna = 1;
                    }

                    Hotel hotel = new Hotel(textBoxName.Text, int.Parse(textBoxPrice.Text), int.Parse(textBoxPeople.Text), int.Parse(textBoxKm.Text), wifi, sauna, textBoxPhoto1.Text, textBoxPhoto2.Text);
                    item.Hotels.Add(hotel);
                    
                }
                listViewHotels.Items.Clear();
                foreach (var h in item.Hotels)
                {
                    listViewHotels.Items.Add(h.Name);
                }
            }
            Serialization.Serialize(lr);
        }
    }
}
