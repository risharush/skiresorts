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
using System.IO;
using System.Xml.Serialization;

namespace Ski_Resorts
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public ListOfResorts lr = null;
        public string file = "../../allresorts.xml";
        public Admin()
        {
            InitializeComponent();


            if (File.Exists("../../allresorts.xml"))
            {
                listView.Items.Clear();
                lr = Serialization.Deserialize(lr);
                foreach (var item in lr.Res)
                {
                    listView.Items.Add(item.Show());
                }
            }

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminAdd wnd = new AdminAdd();
            wnd.Show();
            this.Close();


            //wnd.buttonHotel.Visibility = Visibility.Visible;
            wnd.buttonAdd.Visibility = Visibility.Visible;
            wnd.buttonAllHotels.Visibility = Visibility.Hidden;
            wnd.buttonEdit.Visibility = Visibility.Hidden;

        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                AdminAdd wnd = new AdminAdd();
                wnd.Show();
                this.Close();
             
                foreach (var item in lr.Res)
                {

                    if (listView.SelectedItem.ToString() == item.Show())
                    {
                        wnd.textBoxName.Text = item.Name;
                        wnd.comboBoxCountry.Text = item.Country;
                        wnd.textBoxKm.Text = item.Km.ToString();
                        wnd.textBoxPeak.Text = item.Highest_Peak.ToString();
                        wnd.textBoxSlope.Text = item.Longest_Slope.ToString();
                        wnd.textBoxLifts.Text = item.Ski_Lifts.ToString();
                        wnd.textBoxSnowparks.Text = item.Snowparks.ToString();
                        wnd.textBoxSkipass.Text = item.Skipass.ToString();
                        if (item.Rink == 1)
                        wnd.checkBoxRink.IsChecked= true;
                        wnd.ski = item;
                    }
                }
                wnd.buttonAllHotels.Visibility = Visibility.Visible;
                wnd.buttonEdit.Visibility = Visibility.Visible;
                //wnd.buttonHotel.Visibility = Visibility.Hidden;
                wnd.buttonAdd.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Выберите курорт!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                foreach (var item in lr.Res)
                {
                    if (item.Show() == listView.SelectedItem.ToString())
                    {
                        lr.Res.Remove(item);
                        break;
                    }
                }
                listView.Items.Clear();
                foreach (var item in lr.Res)
                {
                    listView.Items.Add(item.Show());
                }
                Serialization.Serialize(lr);
            }
            else
            {
                MessageBox.Show("Выберите курорт!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
