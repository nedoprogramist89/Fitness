using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fitnes
{
    public partial class AdminClients : Window
    {
        private FitnesEntities1 _context = new FitnesEntities1(); 

        public AdminClients()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                
                _context.Clients.Load();
                dgrdClients.ItemsSource = _context.Clients.Local; 
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
                
                var newClient = new Clients
                {
                    CompanyName = TextBoxCompanyName.Text,
                    PhoneNumber = TextBoxPhoneNumber.Text,
                    Address = TextBoxAddress.Text,
                    Email = TextBoxEmail.Text,
                    ContactPersonName = TextBoxContactPersonName.Text,
                    ContactPersonSurname = TextBoxContactPersonSurname.Text,
                    ContactPersonMiddlename = TextBoxContactPersonMiddlename.Text,
                    ContractNumber = int.Parse(TextBoxContractNumber.Text)
                };

                _context.Clients.Add(newClient); 
                _context.SaveChanges(); 

                LoadData(); 
                ClearFields(); 
                MessageBox.Show("Клиент успешно добавлен!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}");
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdClients.SelectedItem is Clients selectedClient)
            {
                try
                {
                    
                    selectedClient.CompanyName = TextBoxCompanyName.Text;
                    selectedClient.PhoneNumber = TextBoxPhoneNumber.Text;
                    selectedClient.Address = TextBoxAddress.Text;
                    selectedClient.Email = TextBoxEmail.Text;
                    selectedClient.ContactPersonName = TextBoxContactPersonName.Text;
                    selectedClient.ContactPersonSurname = TextBoxContactPersonSurname.Text;
                    selectedClient.ContactPersonMiddlename = TextBoxContactPersonMiddlename.Text;
                    selectedClient.ContractNumber = int.Parse(TextBoxContractNumber.Text);

                    _context.SaveChanges(); 
                    LoadData(); 
                    MessageBox.Show("Клиент успешно изменен!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании клиента: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования!", "Ошибка");
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdClients.SelectedItem is Clients selectedClient)
            {
                try
                {
                    _context.Clients.Remove(selectedClient); 
                    _context.SaveChanges(); 
                    LoadData(); 
                    MessageBox.Show("Клиент успешно удален!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении клиента: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления!", "Ошибка");
            }
        }

        private void dgrdClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgrdClients.SelectedItem is Clients selectedClient)
            {
                
                TextBoxCompanyName.Text = selectedClient.CompanyName;
                TextBoxPhoneNumber.Text = selectedClient.PhoneNumber;
                TextBoxAddress.Text = selectedClient.Address;
                TextBoxEmail.Text = selectedClient.Email;
                TextBoxContactPersonName.Text = selectedClient.ContactPersonName;
                TextBoxContactPersonSurname.Text = selectedClient.ContactPersonSurname;
                TextBoxContactPersonMiddlename.Text = selectedClient.ContactPersonMiddlename;
                TextBoxContractNumber.Text = selectedClient.ContractNumber.ToString();
            }
        }

        private void ClearFields()
        {
            
            TextBoxCompanyName.Clear();
            TextBoxPhoneNumber.Clear();
            TextBoxAddress.Clear();
            TextBoxEmail.Clear();
            TextBoxContactPersonName.Clear();
            TextBoxContactPersonSurname.Clear();
            TextBoxContactPersonMiddlename.Clear();
            TextBoxContractNumber.Clear();
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