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

namespace Ski_Resorts
{
    /// <summary>
    /// Логика взаимодействия для Hotels.xaml
    /// </summary>
    public partial class Hotels : Window
    {
        
        public ListOfResorts lr = new ListOfResorts();
        public List<Hotel> hotels = new List<Hotel>();
        public Hotels()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Resort wnd = new Resort();
                if (wnd.Visibility == Visibility.Hidden)
                {
                    wnd.Show();
                }
                Close();
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
                Resort w = new Resort();
                if (listViewHotels.SelectedIndex != 0)
                {
                    buttonPrev.Visibility = Visibility.Visible;
                }
                else
                    buttonPrev.Visibility = Visibility.Hidden;
                if (listViewHotels.SelectedIndex != (listViewHotels.Items.Count - 1))
                {
                    buttonNext.Visibility = Visibility.Visible;
                }
                else
                    buttonNext.Visibility = Visibility.Hidden;
                lr = Serialization.Deserialize(lr);
                if (listViewHotels.SelectedItem != null)
                {
                    if (listViewHotels.SelectedItem.ToString() == "К сожалению,\nвсе отели вблизи\nданного курорта\nзабронированы:(")

                        buttonBook.Visibility = Visibility.Hidden;
                    else
                    buttonBook.Visibility = Visibility.Visible;
                    foreach (var res in lr.Res)
                    {
                        if (labelRes.Content.ToString() == res.Name)
                        {
                            foreach (var h in res.Hotels)
                            {
                                if (listViewHotels.SelectedItem.ToString() == h.Name)
                                {
                                    string wifi = "Wifi нет, ";
                                    if (h.Wifi == 1)
                                    {
                                        wifi = "Wifi есть, ";
                                    }
                                    string sauna = "сауны нет";
                                    if (h.Sauna == 1)
                                    {
                                        sauna = "сауна есть";
                                    }
                                    labelName.Content = h.Name;
                                    labelPrice.Content = "Цена за неделю: " + h.Price + "€";
                                    labelPeople.Content = "Кол-во людей: " + h.People;
                                    labelKm.Content = "Км от отеля: " + h.Km;
                                    labelWifiSauna.Content = wifi + sauna;
                                    image1.Source = new BitmapImage(new Uri(h.Photo1));
                                    image2.Source = new BitmapImage(new Uri(h.Photo2));
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lr = Serialization.Deserialize(lr);
                foreach (var res in lr.Res)
                {
                    foreach (var h in res.Hotels)
                    {
                        if (listViewHotels.SelectedItem.ToString() == h.Name)
                        {
                            int index = res.Hotels.IndexOf(h);
                            if (index != 0)
                            {
                                index -= 1;

                            }
                            else
                                buttonPrev.Visibility = Visibility.Hidden;

                            Hotel hot = res.Hotels.GetRange(index, 1)[0];
                            listViewHotels.SelectedIndex = index;
                            string wifi = "Wifi нет, ";
                            if (hot.Wifi == 1)
                            {
                                wifi = "Wifi есть, ";
                            }
                            string sauna = "сауны нет";
                            if (hot.Sauna == 1)
                            {
                                sauna = "сауна есть";
                            }
                            labelName.Content = hot.Name;
                            labelPrice.Content = "Цена за неделю: " + hot.Price;
                            labelPeople.Content = "Кол-во людей: " + hot.People;
                            labelKm.Content = "Км от отеля: " + hot.Km;
                            labelWifiSauna.Content = wifi + sauna;
                            image1.Source = new BitmapImage(new Uri(h.Photo1));
                            image2.Source = new BitmapImage(new Uri(h.Photo2));
                            break;

                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lr = Serialization.Deserialize(lr);
                foreach (var res in lr.Res)
                {
                    foreach (var h in res.Hotels)
                    {
                        if (listViewHotels.SelectedItem.ToString() == h.Name)
                        {
                            int index = res.Hotels.IndexOf(h);
                            if (index != (listViewHotels.Items.Count - 1))
                            {
                                index += 1;

                            }
                            else
                                buttonPrev.Visibility = Visibility.Hidden;

                            Hotel hot = res.Hotels.GetRange(index, 1)[0];
                            listViewHotels.SelectedIndex = index;
                            string wifi = "Wifi нет, ";
                            if (hot.Wifi == 1)
                            {
                                wifi = "Wifi есть, ";
                            }
                            string sauna = "сауны нет";
                            if (hot.Sauna == 1)
                            {
                                sauna = "сауна есть";
                            }
                            labelName.Content = hot.Name;
                            labelPrice.Content = "Цена за неделю: " + hot.Price + "€";
                            labelPeople.Content = "Кол-во людей: " + hot.People;
                            labelKm.Content = "До ближайшего подъёмника: " + hot.Km + " км";
                            labelWifiSauna.Content = wifi + sauna;
                            image1.Source = new BitmapImage(new Uri(h.Photo1));
                            image2.Source = new BitmapImage(new Uri(h.Photo2));
                            break;

                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void buttonBook_Click(object sender, RoutedEventArgs e)
        {
            Booking wnd = new Booking();
            wnd.Show();
        }
    }
}
