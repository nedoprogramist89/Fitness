using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fitnes
{
    public partial class DirectorWindowOrder : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Orders> _orders;

        public ObservableCollection<Orders> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public DirectorWindowOrder()
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
                    Orders = new ObservableCollection<Orders>(
                        context.Orders
                            .Include(o => o.Clients)        
                            .Include(o => o.Technique)     
                            .Include(o => o.OrderStatus)    
                            .Include(o => o.Employees)      
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