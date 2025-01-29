using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fitnes
{
    public partial class AdminEmployee : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Employees> _employees;
        private ObservableCollection<JobTitle> _jobTitles;
        private Employees _selectedEmployee;

        public ObservableCollection<Employees> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public ObservableCollection<JobTitle> JobTitles
        {
            get => _jobTitles;
            set
            {
                _jobTitles = value;
                OnPropertyChanged(nameof(JobTitles));
            }
        }

        public Employees SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            
                if (_selectedEmployee != null)
                {
                    TextBoxEmployeeName.Text = _selectedEmployee.EmployeeName;
                    TextBoxEmployeeSurname.Text = _selectedEmployee.EmployeeSurname;
                    TextBoxEmployeeMiddlename.Text = _selectedEmployee.EmployeeMiddlename;
                    TextBoxPhoneNumber.Text = _selectedEmployee.PhoneNumber;
                    TextBoxEmail.Text = _selectedEmployee.Email;
                    TextBoxPassword.Text = _selectedEmployee.Password;
                    ComboBoxJobTitle.SelectedValue = _selectedEmployee.JobTitle_ID;
                }
            }
        }

        public AdminEmployee()
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
            
                    Employees = new ObservableCollection<Employees>(context.Employees.Include(e => e.JobTitle).ToList());
                    JobTitles = new ObservableCollection<JobTitle>(context.JobTitle.ToList());
                    ComboBoxJobTitle.ItemsSource = JobTitles;
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
            
                if (string.IsNullOrWhiteSpace(TextBoxEmployeeName.Text) || string.IsNullOrWhiteSpace(TextBoxEmployeeSurname.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxPhoneNumber.Text) || string.IsNullOrWhiteSpace(TextBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxPassword.Text) || ComboBoxJobTitle.SelectedValue == null)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new FitnesEntities1())
                {
                    var newEmployee = new Employees
                    {
                        EmployeeName = TextBoxEmployeeName.Text,
                        EmployeeSurname = TextBoxEmployeeSurname.Text,
                        EmployeeMiddlename = TextBoxEmployeeMiddlename.Text,
                        PhoneNumber = TextBoxPhoneNumber.Text,
                        Email = TextBoxEmail.Text,
                        Password = TextBoxPassword.Text,
                        JobTitle_ID = (int)ComboBoxJobTitle.SelectedValue
                    };

                    context.Employees.Add(newEmployee);
                    context.SaveChanges();

     
                    Employees.Add(newEmployee);
                    MessageBox.Show("Сотрудник успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника для редактирования!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
            
                if (string.IsNullOrWhiteSpace(TextBoxEmployeeName.Text) || string.IsNullOrWhiteSpace(TextBoxEmployeeSurname.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxPhoneNumber.Text) || string.IsNullOrWhiteSpace(TextBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxPassword.Text) || ComboBoxJobTitle.SelectedValue == null)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new FitnesEntities1())
                {
                    var employeeToUpdate = context.Employees.Find(SelectedEmployee.ID_Employees);
                    if (employeeToUpdate != null)
                    {
                        employeeToUpdate.EmployeeName = TextBoxEmployeeName.Text;
                        employeeToUpdate.EmployeeSurname = TextBoxEmployeeSurname.Text;
                        employeeToUpdate.EmployeeMiddlename = TextBoxEmployeeMiddlename.Text;
                        employeeToUpdate.PhoneNumber = TextBoxPhoneNumber.Text;
                        employeeToUpdate.Email = TextBoxEmail.Text;
                        employeeToUpdate.Password = TextBoxPassword.Text;
                        employeeToUpdate.JobTitle_ID = (int)ComboBoxJobTitle.SelectedValue;

                        context.SaveChanges();

            
                        var index = Employees.IndexOf(SelectedEmployee);
                        Employees[index] = employeeToUpdate;
                        MessageBox.Show("Сотрудник успешно изменен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании сотрудника: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new FitnesEntities1())
                {
                    var employeeToDelete = context.Employees.Find(SelectedEmployee.ID_Employees);
                    if (employeeToDelete != null)
                    {
                        context.Employees.Remove(employeeToDelete);
                        context.SaveChanges();

               
                        Employees.Remove(SelectedEmployee);
                        MessageBox.Show("Сотрудник успешно удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении сотрудника: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBoxEmployeeName.Text = null;
            TextBoxEmployeeSurname.Text = null;
            TextBoxEmployeeMiddlename.Text = null;
            TextBoxPhoneNumber.Text = null;
            TextBoxEmail.Text = null;
            TextBoxPassword.Text = null;
            ComboBoxJobTitle.SelectedValue = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }
    }
}