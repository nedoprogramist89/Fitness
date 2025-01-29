using Fitnes;
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

namespace Fitnes
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var adminTechnique = new AdminTechnique();
            adminTechnique.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var adminClient = new AdminClients();
            adminClient.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var adminOrder = new AdminOrder();
            adminOrder.Show();
            this.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var adminMaintenance = new AdminMaintenance();
            adminMaintenance.Show();
            this.Close();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var adminEmployee = new AdminEmployee();
            adminEmployee.Show();
            this.Close();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
  
}