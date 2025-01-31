using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fitnes
{
    public partial class AdminEmployee : Window
    {
        private FitnesEntities1 _context = new FitnesEntities1(); 

        public AdminEmployee()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                
                _context.Employees.Load(); 
                _context.JobTitle.Load(); 
                dgrdEmployees.ItemsSource = _context.Employees.Local; 
                ComboBoxJobTitle.ItemsSource = _context.JobTitle.Local; 
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

                _context.Employees.Add(newEmployee); 
                _context.SaveChanges(); 

                LoadData(); 
                ClearFields(); 
                MessageBox.Show("Сотрудник успешно добавлен!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}");
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdEmployees.SelectedItem is Employees selectedEmployee)
            {
                try
                {
                    
                    selectedEmployee.EmployeeName = TextBoxEmployeeName.Text;
                    selectedEmployee.EmployeeSurname = TextBoxEmployeeSurname.Text;
                    selectedEmployee.EmployeeMiddlename = TextBoxEmployeeMiddlename.Text;
                    selectedEmployee.PhoneNumber = TextBoxPhoneNumber.Text;
                    selectedEmployee.Email = TextBoxEmail.Text;
                    selectedEmployee.Password = TextBoxPassword.Text;
                    selectedEmployee.JobTitle_ID = (int)ComboBoxJobTitle.SelectedValue;

                    _context.SaveChanges(); 
                    LoadData(); 
                    MessageBox.Show("Сотрудник успешно изменен!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании сотрудника: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования!", "Ошибка");
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdEmployees.SelectedItem is Employees selectedEmployee)
            {
                try
                {
                    _context.Employees.Remove(selectedEmployee); 
                    _context.SaveChanges(); 
                    LoadData(); 
                    MessageBox.Show("Сотрудник успешно удален!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении сотрудника: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления!", "Ошибка");
            }
        }

        private void dgrdEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgrdEmployees.SelectedItem is Employees selectedEmployee)
            {
                
                TextBoxEmployeeName.Text = selectedEmployee.EmployeeName;
                TextBoxEmployeeSurname.Text = selectedEmployee.EmployeeSurname;
                TextBoxEmployeeMiddlename.Text = selectedEmployee.EmployeeMiddlename;
                TextBoxPhoneNumber.Text = selectedEmployee.PhoneNumber;
                TextBoxEmail.Text = selectedEmployee.Email;
                TextBoxPassword.Text = selectedEmployee.Password;
                ComboBoxJobTitle.SelectedValue = selectedEmployee.JobTitle_ID;
            }
        }

        private void ClearFields()
        {
          
            TextBoxEmployeeName.Clear();
            TextBoxEmployeeSurname.Clear();
            TextBoxEmployeeMiddlename.Clear();
            TextBoxPhoneNumber.Clear();
            TextBoxEmail.Clear();
            TextBoxPassword.Clear();
            ComboBoxJobTitle.SelectedIndex = -1;
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