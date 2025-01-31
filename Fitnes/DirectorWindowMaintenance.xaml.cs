using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fitnes
{
    public partial class DirectorWindowMaintenance : Window
    {
        private FitnesEntities1 _context = new FitnesEntities1(); 

        public DirectorWindowMaintenance()
        {
            InitializeComponent();
            _context.Maintenance
                .Include(m => m.MaintenanceStatus) 
                .Include(m => m.Technique) 
                .Load();

            dgrdMaintenance.ItemsSource = _context.Maintenance.Local; 
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
            var directorWindow = new DirectorWindow();
            directorWindow.Show();
            this.Close();
        }
    }
}