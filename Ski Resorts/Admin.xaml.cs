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
            
            lr = Serialization.Deserialize(lr);
                foreach (var item in lr.Res)
                {
                    string str = item.Name + ' ' + item.Country + ' ' + item.Highest_Peak + ' ' + item.Km + ' ' + item.Longest_Slope + ' ' + item.Ski_Lifts + ' ' + item.Snowparks + ' ' + item.Rink + ' ' + item.Skipass;
                    listView.Items.Add(str);
                }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdminAdd wnd = new AdminAdd();
            wnd.Show();
            this.Close();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }
    }
}
