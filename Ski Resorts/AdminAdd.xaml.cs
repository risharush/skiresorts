using System;
using System.Collections.Generic;
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
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;

namespace Ski_Resorts
{
    
    
    /// <summary>
    /// Логика взаимодействия для AdminAdd.xaml
    /// </summary>
    public partial class AdminAdd : Window
    {
        public ListOfResorts lr = new ListOfResorts();
        public List<Hotel> hotels = new List<Hotel>();
        public Ski_Resort ski = new Ski_Resort();

        public string file = "../../allresorts.xml";

        public AdminAdd()
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

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == null || comboBoxCountry.Text == null || textBoxPeak.Text == null || textBoxSlope.Text == null || textBoxKm.Text == null || textBoxSnowparks.Text == null || textBoxSkipass.Text == null)
                MessageBox.Show("Заполните все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Hand);
            else
            {
                int rink = 0;
                if (checkBoxRink.IsChecked ?? false)
                {
                    rink = 1;
                }

                Ski_Resort sr = new Ski_Resort(textBoxName.Text, comboBoxCountry.Text, int.Parse(textBoxPeak.Text), int.Parse(textBoxKm.Text), int.Parse(textBoxSlope.Text), int.Parse(textBoxLifts.Text), int.Parse(textBoxSnowparks.Text), rink, int.Parse(textBoxSkipass.Text), textBoxPhoto.Text, hotels);

                lr.Res.Add(sr);
                Serialization.Serialize(lr);

                Admin wnd = new Admin();
                wnd.Show();
                Close();
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            Admin wnd = new Admin();
            wnd.Show();
            Close();
        }

        private void buttonPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "jpeg|*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                var fileN = openFileDialog.FileName;
                var nPath = System.IO.Path.GetFileName(fileN);
                var curPAth = System.Reflection.Assembly.GetExecutingAssembly().Location;
                nPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(curPAth) + "/photo/", nPath);

                File.Copy(fileN, nPath, true);
                BitmapImage photo;
                photo = new BitmapImage(new Uri(nPath));
                textBoxPhoto.Text = nPath;
            }
        }

        private void buttonHotel_Click(object sender, RoutedEventArgs e)
        {
            AddHotel wnd = new AddHotel();
            wnd.Show();
        }

        /*СОХРАНИТЬ */
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../../allresorts.xml"))
            {
                lr = Serialization.Deserialize(lr);
            }
            foreach (var item in lr.Res)
            {
                if (ski.Name == item.Name)
                {
                    item.Name = textBoxName.Text;
                    item.Country = comboBoxCountry.Text;
                    item.Km = int.Parse(textBoxKm.Text);
                    item.Highest_Peak = int.Parse(textBoxPeak.Text);
                    item.Longest_Slope = int.Parse(textBoxSlope.Text);
                    item.Ski_Lifts = int.Parse(textBoxLifts.Text);
                    item.Snowparks = int.Parse(textBoxSnowparks.Text);
                    item.Skipass = int.Parse(textBoxSkipass.Text);
                    if (checkBoxRink.IsChecked ?? false)
                        item.Rink = 1;
                    else
                        item.Rink = 0;
                    break;
                }
            }
            

            Serialization.Serialize(lr);

            Admin wnd = new Admin();
            wnd.Show();
            Close();

           
        }

        private void buttonAllHotels_Click(object sender, RoutedEventArgs e)
        {


            AddHotel wnd = new AddHotel();
            wnd.Show();
            wnd.ski3 = ski;

            wnd.listViewHotels.Items.Clear();
            foreach (var item in wnd.lr.Res)
            {
                if (ski.Name == item.Name)
                {
                    foreach (var h in item.Hotels)
                    {
                        wnd.listViewHotels.Items.Add(h.Name);
                    }
                }
            }

        }
    }
}
