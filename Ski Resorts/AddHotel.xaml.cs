using Microsoft.Win32;
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
            try
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
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }

        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
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
                        if (checkBoxSauna.IsChecked ?? false)
                        {
                            sauna = 1;
                        }

                        Hotel hotel = new Hotel(textBoxName.Text, int.Parse(textBoxPrice.Text), int.Parse(textBoxPeople.Text), int.Parse(textBoxKm.Text), wifi, sauna, textBoxPhoto1.Text, textBoxPhoto2.Text);
                        item.Hotels.Add(hotel);
                        hotels.Add(hotel);

                        listViewHotels.Items.Clear();
                        foreach (var h in item.Hotels)
                        {
                            listViewHotels.Items.Add(h.Name);
                        }
                        sauna = 0;
                        wifi = 0;
                    }
                }
                Log.Logir("Добавлен отель " + textBoxName.Text + " " + DateTime.Now);

                textBoxName.Clear();
                textBoxPeople.Clear();
                textBoxKm.Clear();
                textBoxPhoto1.Clear();
                textBoxPhoto2.Clear();
                textBoxPrice.Clear();
                checkBoxSauna.IsChecked = false;
                checkBoxWifi.IsChecked = false;

                Serialization.Serialize(lr);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void listViewHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                buttonAdd.Visibility = Visibility.Hidden;
                buttonSave.Visibility = Visibility.Visible;
                buttonChange.Visibility = Visibility.Visible;
                buttonDelete.Visibility = Visibility.Visible;
                foreach (var item in hotels)
                {
                    if (listViewHotels.SelectedItem != null)
                    {
                        if (item.Name == listViewHotels.SelectedItem.ToString())
                        {
                            textBoxName.Text = item.Name;
                            textBoxPeople.Text = item.People.ToString();
                            textBoxKm.Text = item.Km.ToString();
                            textBoxPrice.Text = item.Price.ToString();
                            textBoxPhoto1.Text = item.Photo1.ToString();
                            textBoxPhoto2.Text = item.Photo2.ToString();
                            if (item.Wifi == 1)
                                checkBoxWifi.IsChecked = true;
                            else
                                checkBoxWifi.IsChecked = false;
                            if (item.Sauna == 1)
                                checkBoxSauna.IsChecked = true;
                            else
                                checkBoxSauna.IsChecked = false;
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                textBoxName.Clear();
                textBoxPeople.Clear();
                textBoxKm.Clear();
                textBoxPrice.Clear();
                textBoxPhoto1.Clear();
                textBoxPhoto2.Clear();
                checkBoxWifi.IsChecked = false;
                checkBoxSauna.IsChecked = false;
                buttonSave.Visibility = Visibility.Hidden;
                buttonAdd.Visibility = Visibility.Visible;
                buttonChange.Visibility = Visibility.Hidden;
                buttonDelete.Visibility = Visibility.Hidden;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in hotels)
                {
                    if (listViewHotels.SelectedItem != null)
                        if (item.Name == listViewHotels.SelectedItem.ToString())
                        {
                            int wifi = 0;
                            if (checkBoxWifi.IsChecked ?? false)
                            {
                                wifi = 1;
                            }

                            int sauna = 0;
                            if (checkBoxSauna.IsChecked ?? false)
                            {
                                sauna = 1;
                            }
                            item.Name = textBoxName.Text;
                            item.People = int.Parse(textBoxPeople.Text);
                            item.Km = int.Parse(textBoxKm.Text);
                            item.Price = int.Parse(textBoxPrice.Text);
                            item.Photo1 = textBoxPhoto1.Text;
                            item.Photo2 = textBoxPhoto2.Text;
                            item.Wifi = wifi;
                            item.Sauna = sauna;
                        }
                }

                Log.Logir("Измена информация об отеле " + textBoxName.Text + " " + DateTime.Now);

                Serialization.Serialize(lr);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }


        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in hotels)
                {
                    if (item.Name == listViewHotels.SelectedItem.ToString())
                    {
                        int i = hotels.IndexOf(item);
                        hotels.RemoveAt(i);
                        break;
                    }
                }
                foreach (var item in lr.Res)
                    foreach (var h in item.Hotels)
                    {

                        if (h.Name == listViewHotels.SelectedItem.ToString())
                        {
                            int i = item.Hotels.IndexOf(h);
                            item.Hotels.RemoveAt(i);
                            break;
                        }
                    }
                listViewHotels.Items.Clear();
                foreach (var item in hotels)
                {
                    listViewHotels.Items.Add(item.Name);
                }

                Log.Logir("Удалён отель " + textBoxName.Text + " " + DateTime.Now);

                textBoxName.Clear();
                textBoxPeople.Clear();
                textBoxKm.Clear();
                textBoxPhoto1.Clear();
                textBoxPhoto2.Clear();
                textBoxPrice.Clear();
                checkBoxSauna.IsChecked = false;
                checkBoxWifi.IsChecked = false;

                Serialization.Serialize(lr);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void buttonPhoto1_Click(object sender, RoutedEventArgs e)
        {
            try
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
                    textBoxPhoto1.Text = nPath;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void buttonPhoto2_Click(object sender, RoutedEventArgs e)
        {
            try
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
                    textBoxPhoto2.Text = nPath;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
    }
}
