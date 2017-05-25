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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;

namespace Ski_Resorts
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ListOfResorts lr = new ListOfResorts();
        public List<Hotel> hotels = new List<Hotel>();

        public MainWindow()
        {
            InitializeComponent();
            lr.Res = new List<Ski_Resort>();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Logir("Вход пользователя " + DateTime.Now);
                User wnd = new User();
                wnd.Show();
                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Password wnd = new Password();
            wnd.Show();
            this.Close();
        }
    }
}
