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
    /// Логика взаимодействия для Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password()
        {
            InitializeComponent();
            passwordBox.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passwordBox.Password.ToString() == "12345")
                {
                    Log.Logir("Вход администратора " + DateTime.Now);
                    Admin wnd = new Admin();
                    wnd.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Log.Logir("Произведена попытка входа " + DateTime.Now);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
    }
}
