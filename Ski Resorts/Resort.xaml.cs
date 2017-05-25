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
    /// Логика взаимодействия для Resort.xaml
    /// </summary>
    public partial class Resort : Window
    {
        public ListOfResorts lr = new ListOfResorts();

        public int f = 0;
        public Resort()
        {
            InitializeComponent();
            lr = Serialization.Deserialize(lr);
        }

        private void buttonHotel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hotels wnd = new Hotels();
                wnd.Show();
                
                foreach (var item in lr.Res)
                {
                    if (labelName.Content.ToString() == "Курорт: " + item.Name)
                    {
                        wnd.labelRes.Content = item.Name;

                        foreach (var h in item.Hotels)
                        {
                            wnd.listViewHotels.Items.Add(h.Name);
                            f++;
                        }
                    }
                }
                if (f == 0)
                {
                    wnd.listViewHotels.Items.Add("К сожалению,\nвсе отели вблизи\nданного курорта\nзабронированы:(");
                    wnd.buttonBook.Visibility = Visibility.Hidden;
                }
                
                Serialization.Serialize(lr);
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
    }
}
