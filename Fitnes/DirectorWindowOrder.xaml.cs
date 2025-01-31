using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fitnes
{
    public partial class DirectorWindowOrder : Window
    {
        private FitnesEntities1 _context = new FitnesEntities1(); 

        public DirectorWindowOrder()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                
                _context.Orders
                    .Include(o => o.Clients)         
                    .Include(o => o.Technique)       
                    .Include(o => o.OrderStatus)     
                    .Include(o => o.Employees)      
                    .Load();

                dgrdOrders.ItemsSource = _context.Orders.Local;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var directorWindow = new DirectorWindow();
            directorWindow.Show();
            this.Close();
        }
    }
}