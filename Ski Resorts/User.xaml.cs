﻿using System;
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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public ListOfResorts lr = new ListOfResorts();
        public User()
        {
            InitializeComponent();

            lr = Serialization.Deserialize(lr);
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            MainWindow wnd = new MainWindow();
            wnd.Show();
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserList wnd = new UserList();
                wnd.Show();
                Close();

                int f = 0;
                foreach (Ski_Resort item in lr.Res)
                {
                    int snow = 0;
                    if (checkBoxSnowpark.IsChecked ?? false)
                    {
                        snow = 1;
                    }
                    int rink = 0;
                    if (checkBoxRink.IsChecked ?? false)
                    {
                        rink = 1;
                    }
                    if ((comboBoxCountry.Text == item.Country || comboBoxCountry.Text == "Любая") && (snow == 1 && item.Snowparks >= 1 || snow == 0) && (rink == 1 && item.Rink == 1 || rink == 0) && (int.Parse(textBoxKm.Text) <= item.Km) && (int.Parse(textBoxSkipass.Text) >= item.Skipass))
                    {
                        wnd.listViewResorts.Items.Add(item.Name + ' ' + item.Country);
                        f++;
                    }
                }
                if (f == 0)
                {
                    wnd.listViewResorts.Items.Add("По вашему запросу\nничего не найдено!");
                    wnd.button1.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
    }
}
