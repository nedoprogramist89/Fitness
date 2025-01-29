using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fitnes
{
    public partial class DirectorWindowMaintenance : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Maintenance> _maintenances;

        public ObservableCollection<Maintenance> Maintenances
        {
            get => _maintenances;
            set
            {
                _maintenances = value;
                OnPropertyChanged(nameof(Maintenances));
            }
        }

        public DirectorWindowMaintenance()
        {
            InitializeComponent();
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new FitnesEntities1())
                {
                    Maintenances = new ObservableCollection<Maintenance>(
                        context.Maintenance
                            .Include(m => m.MaintenanceStatus) 
                            .Include(m => m.Technique) 
                            .ToList()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка загрузки данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var directorWindow = new DirectorWindow();
            directorWindow.Show();
            this.Close();
        }
    }
}