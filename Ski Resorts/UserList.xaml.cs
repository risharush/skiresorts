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
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public partial class UserList : Window
    {
        public ListOfResorts lr = new ListOfResorts();
        public UserList()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            User wnd = new User();
            wnd.Show();
            Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listViewResorts.SelectedItem != null)
                {
                    Resort wnd = new Resort();
                    wnd.Show();

                    string sel = listViewResorts.SelectedItem.ToString();
                    string name = sel.Split(' ')[0];
                    string rink = null;
                    string snowparks = null;
                    lr = Serialization.Deserialize(lr);
                    foreach (Ski_Resort res in lr.Res)
                    {
                        if (res.Name == name)
                        {
                            if (res.Rink == 1)
                                rink = "хелиски есть";
                            else
                                rink = "хелиски нет";
                            if (res.Snowparks >= 1)
                                snowparks = "Кол-во сноупарков: " + res.Snowparks + ", ";
                            else
                                snowparks = "Сноупарка нет, ";

                            wnd.labelName.Content = "Курорт: " + res.Name;
                            wnd.labelCountry.Content = "Страна: " + res.Country;
                            wnd.labelPeak.Content = "Пик: " + res.Highest_Peak + " м";
                            wnd.labelKm.Content = "Протяжённость трасс: " + res.Km + " км";
                            wnd.labelSlope.Content = "Самая длинная трасса: " + res.Longest_Slope + " км";
                            wnd.labelLifts.Content = "Кол-во подъёмников: " + res.Ski_Lifts;
                            wnd.labelSnow.Content = snowparks + rink;
                            wnd.labelSkipass.Content = "Стоимость скипасса на неделю: " + res.Skipass + "€";
                            wnd.image.Source = new BitmapImage(new Uri(res.Photo));
                        }
                    }
                }
                else
                    MessageBox.Show("Выберите курорт!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
    }
}
