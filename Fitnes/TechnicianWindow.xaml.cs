using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;

namespace Fitnes
{
    public partial class TechnicianWindow : Window
    {
        private FitnesEntities1 _context = new FitnesEntities1(); 

        public TechnicianWindow()
        {
            InitializeComponent();
            _context.Maintenance
                    .Include(m => m.MaintenanceStatus) 
                    .Include(m => m.Technique) 
                    .Load();

            dgrdMaintenances.ItemsSource = _context.Maintenance.Local;
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}