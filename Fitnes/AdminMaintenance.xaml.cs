using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fitnes
{
    public partial class AdminMaintenance : Window
    {
        private FitnesEntities1 _context = new FitnesEntities1(); 

        public AdminMaintenance()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                
                _context.Maintenance.Load(); 
                _context.MaintenanceStatus.Load(); 
                _context.Technique.Load(); 

                dgrdMaintenance.ItemsSource = _context.Maintenance.Local; 
                ComboBoxMaintenanceStatus.ItemsSource = _context.MaintenanceStatus.Local; 
                ComboBoxTechnique.ItemsSource = _context.Technique.Local; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             
                if (string.IsNullOrWhiteSpace(TextBoxMaintenanceDate.Text) || string.IsNullOrWhiteSpace(TextBoxTypeOfWork.Text) ||
                    ComboBoxMaintenanceStatus.SelectedValue == null || ComboBoxTechnique.SelectedValue == null)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных");
                    return;
                }

        
                var newMaintenance = new Maintenance
                {
                    MaintenanceDate = TextBoxMaintenanceDate.Text,
                    TypeOfWork = TextBoxTypeOfWork.Text,
                    MaintenanceStatus_ID = (int)ComboBoxMaintenanceStatus.SelectedValue,
                    Technique_ID = (int)ComboBoxTechnique.SelectedValue
                };

                _context.Maintenance.Add(newMaintenance);
                _context.SaveChanges();

                LoadData(); 
                ClearFields();
                MessageBox.Show("Обслуживание успешно добавлено!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении обслуживания: {ex.Message}");
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdMaintenance.SelectedItem is Maintenance selectedMaintenance)
            {
                try
                {
                    
                    if (string.IsNullOrWhiteSpace(TextBoxMaintenanceDate.Text) || string.IsNullOrWhiteSpace(TextBoxTypeOfWork.Text) ||
                        ComboBoxMaintenanceStatus.SelectedValue == null || ComboBoxTechnique.SelectedValue == null)
                    {
                        MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных");
                        return;
                    }

                    
                    selectedMaintenance.MaintenanceDate = TextBoxMaintenanceDate.Text;
                    selectedMaintenance.TypeOfWork = TextBoxTypeOfWork.Text;
                    selectedMaintenance.MaintenanceStatus_ID = (int)ComboBoxMaintenanceStatus.SelectedValue;
                    selectedMaintenance.Technique_ID = (int)ComboBoxTechnique.SelectedValue;

                    _context.SaveChanges(); 
                    LoadData(); 
                    MessageBox.Show("Обслуживание успешно изменено!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании обслуживания: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите обслуживание для редактирования!", "Ошибка");
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdMaintenance.SelectedItem is Maintenance selectedMaintenance)
            {
                try
                {
                    _context.Maintenance.Remove(selectedMaintenance); 
                    _context.SaveChanges(); 
                    LoadData(); 
                    MessageBox.Show("Обслуживание успешно удалено!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении обслуживания: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите обслуживание для удаления!", "Ошибка");
            }
        }

        private void dgrdMaintenance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgrdMaintenance.SelectedItem is Maintenance selectedMaintenance)
            {
                
                TextBoxMaintenanceDate.Text = selectedMaintenance.MaintenanceDate;
                TextBoxTypeOfWork.Text = selectedMaintenance.TypeOfWork;
                ComboBoxMaintenanceStatus.SelectedValue = selectedMaintenance.MaintenanceStatus_ID;
                ComboBoxTechnique.SelectedValue = selectedMaintenance.Technique_ID;
            }
        }

        private void ClearFields()
        {
           
            TextBoxMaintenanceDate.Clear();
            TextBoxTypeOfWork.Clear();
            ComboBoxMaintenanceStatus.SelectedIndex = -1;
            ComboBoxTechnique.SelectedIndex = -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
            var adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearFields(); 
        }
    }
}