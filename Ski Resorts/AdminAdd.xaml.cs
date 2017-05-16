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

namespace Ski_Resorts
{
    
    /// <summary>
    /// Логика взаимодействия для AdminAdd.xaml
    /// </summary>
    public partial class AdminAdd : Window
    {
        public ListOfResorts lr = null;
        public string file = "../../allresorts.xml";

        public AdminAdd()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int rink = 0;
            if (checkBoxRink.IsChecked ?? false)
            {
                rink = 1;
            }
            
                lr = Serialization.Deserialize(lr);

            Ski_Resort sr = new Ski_Resort(textBoxName.Text, comboBoxCountry.Text, int.Parse(textBoxPeak.Text), int.Parse(textBoxKm.Text), int.Parse(textBoxSlope.Text), int.Parse(textBoxLifts.Text), int.Parse(textBoxSnowparks.Text), rink, int.Parse(textBoxSkipass.Text));
           
            lr.Res.Add(sr);
            Serialization.Serialize(lr);

            Admin wnd = new Admin();
            wnd.Show();
            this.Close();
        }

       
    }
}
