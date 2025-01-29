using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fitnes
{
    public partial class AdminMaintenance : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Maintenance> _maintenances;
        private ObservableCollection<MaintenanceStatus> _maintenanceStatuses;
        private ObservableCollection<Technique> _techniques;
        private Maintenance _selectedMaintenance;

        public ObservableCollection<Maintenance> Maintenances
        {
            get => _maintenances;
            set
            {
                _maintenances = value;
                OnPropertyChanged(nameof(Maintenances));
            }
        }

        public ObservableCollection<MaintenanceStatus> MaintenanceStatuses
        {
            get => _maintenanceStatuses;
            set
            {
                _maintenanceStatuses = value;
                OnPropertyChanged(nameof(MaintenanceStatuses));
            }
        }

        public ObservableCollection<Technique> Techniques
        {
            get => _techniques;
            set
            {
                _techniques = value;
                OnPropertyChanged(nameof(Techniques));
            }
        }

        public Maintenance SelectedMaintenance
        {
            get => _selectedMaintenance;
            set
            {
                _selectedMaintenance = value;
                OnPropertyChanged(nameof(SelectedMaintenance));
                if (_selectedMaintenance != null)
                {
                    TextBoxMaintenanceDate.Text = _selectedMaintenance.MaintenanceDate;
                    TextBoxTypeOfWork.Text = _selectedMaintenance.TypeOfWork;
                    ComboBoxMaintenanceStatus.SelectedValue = _selectedMaintenance.MaintenanceStatus_ID;
                    ComboBoxTechnique.SelectedValue = _selectedMaintenance.Technique_ID;
                }
            }
        }

        public AdminMaintenance()
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
                    Maintenances = new ObservableCollection<Maintenance>(context.Maintenance.ToList());

                    MaintenanceStatuses = new ObservableCollection<MaintenanceStatus>(context.MaintenanceStatus.ToList());
                    Techniques = new ObservableCollection<Technique>(context.Technique.ToList());

                    ComboBoxMaintenanceStatus.ItemsSource = MaintenanceStatuses;
                    ComboBoxTechnique.ItemsSource = Techniques;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка загрузки данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxMaintenanceDate.Text) || string.IsNullOrWhiteSpace(TextBoxTypeOfWork.Text) ||
                    ComboBoxMaintenanceStatus.SelectedValue == null || ComboBoxTechnique.SelectedValue == null)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new FitnesEntities1())
                {
                    var newMaintenance = new Maintenance
                    {
                        MaintenanceDate = TextBoxMaintenanceDate.Text,
                        TypeOfWork = TextBoxTypeOfWork.Text,
                        MaintenanceStatus_ID = (int)ComboBoxMaintenanceStatus.SelectedValue,
                        Technique_ID = (int)ComboBoxTechnique.SelectedValue
                    };

                    context.Maintenance.Add(newMaintenance);
                    context.SaveChanges();

                    Maintenances.Add(newMaintenance);
                    MessageBox.Show("Обслуживание успешно добавлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении обслуживания: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMaintenance == null)
            {
                MessageBox.Show("Выберите обслуживание для редактирования!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxMaintenanceDate.Text) || string.IsNullOrWhiteSpace(TextBoxTypeOfWork.Text) ||
                    ComboBoxMaintenanceStatus.SelectedValue == null || ComboBoxTechnique.SelectedValue == null)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new FitnesEntities1())
                {
                    var maintenanceToUpdate = context.Maintenance.Find(SelectedMaintenance.ID_Maintenance);
                    if (maintenanceToUpdate != null)
                    {
                        maintenanceToUpdate.MaintenanceDate = TextBoxMaintenanceDate.Text;
                        maintenanceToUpdate.TypeOfWork = TextBoxTypeOfWork.Text;
                        maintenanceToUpdate.MaintenanceStatus_ID = (int)ComboBoxMaintenanceStatus.SelectedValue;
                        maintenanceToUpdate.Technique_ID = (int)ComboBoxTechnique.SelectedValue;

                        context.SaveChanges();

           
                        var index = Maintenances.IndexOf(SelectedMaintenance);
                        Maintenances[index] = maintenanceToUpdate;
                        MessageBox.Show("Обслуживание успешно изменено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании обслуживания: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMaintenance == null)
            {
                MessageBox.Show("Выберите обслуживание для удаления!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new FitnesEntities1())
                {
                    var maintenanceToDelete = context.Maintenance.Find(SelectedMaintenance.ID_Maintenance);
                    if (maintenanceToDelete != null)
                    {
                        context.Maintenance.Remove(maintenanceToDelete);
                        context.SaveChanges();

           
                        Maintenances.Remove(SelectedMaintenance);
                        MessageBox.Show("Обслуживание успешно удалено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении обслуживания: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBoxMaintenanceDate.Text = null;
            TextBoxTypeOfWork.Text = null;
            ComboBoxMaintenanceStatus.SelectedValue = null;
            ComboBoxTechnique.SelectedValue = _selectedMaintenance.Technique_ID;
        }
    }
}