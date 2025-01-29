using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fitnes
{
    public partial class AdminClients : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Clients> _clients;
        private Clients _selectedClient;

        public ObservableCollection<Clients> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        public Clients SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
               
                if (_selectedClient != null)
                {
                    TextBoxCompanyName.Text = _selectedClient.CompanyName;
                    TextBoxPhoneNumber.Text = _selectedClient.PhoneNumber;
                    TextBoxAddress.Text = _selectedClient.Address;
                    TextBoxEmail.Text = _selectedClient.Email;
                    TextBoxContactPersonName.Text = _selectedClient.ContactPersonName;
                    TextBoxContactPersonSurname.Text = _selectedClient.ContactPersonSurname;
                    TextBoxContactPersonMiddlename.Text = _selectedClient.ContactPersonMiddlename;
                    TextBoxContractNumber.Text = _selectedClient.ContractNumber.ToString();
                }
            }
        }

        public AdminClients()
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
               
                    Clients = new ObservableCollection<Clients>(context.Clients.ToList());
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
             
                if (string.IsNullOrWhiteSpace(TextBoxCompanyName.Text) || string.IsNullOrWhiteSpace(TextBoxPhoneNumber.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxAddress.Text) || string.IsNullOrWhiteSpace(TextBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxContactPersonName.Text) || string.IsNullOrWhiteSpace(TextBoxContactPersonSurname.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxContractNumber.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new FitnesEntities1())
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

                    context.Clients.Add(newClient);
                    context.SaveChanges();

                  
                    Clients.Add(newClient);
                    MessageBox.Show("Клиент успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient == null)
            {
                MessageBox.Show("Выберите клиента для редактирования!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
               
                if (string.IsNullOrWhiteSpace(TextBoxCompanyName.Text) || string.IsNullOrWhiteSpace(TextBoxPhoneNumber.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxAddress.Text) || string.IsNullOrWhiteSpace(TextBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxContactPersonName.Text) || string.IsNullOrWhiteSpace(TextBoxContactPersonSurname.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxContractNumber.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new FitnesEntities1())
                {
                    var clientToUpdate = context.Clients.Find(SelectedClient.ID_Clients);
                    if (clientToUpdate != null)
                    {
                        clientToUpdate.CompanyName = TextBoxCompanyName.Text;
                        clientToUpdate.PhoneNumber = TextBoxPhoneNumber.Text;
                        clientToUpdate.Address = TextBoxAddress.Text;
                        clientToUpdate.Email = TextBoxEmail.Text;
                        clientToUpdate.ContactPersonName = TextBoxContactPersonName.Text;
                        clientToUpdate.ContactPersonSurname = TextBoxContactPersonSurname.Text;
                        clientToUpdate.ContactPersonMiddlename = TextBoxContactPersonMiddlename.Text;
                        clientToUpdate.ContractNumber = int.Parse(TextBoxContractNumber.Text);

                        context.SaveChanges();

                        // Обновление DataGrid
                        var index = Clients.IndexOf(SelectedClient);
                        Clients[index] = clientToUpdate;
                        MessageBox.Show("Клиент успешно изменен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании клиента: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient == null)
            {
                MessageBox.Show("Выберите клиента для удаления!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new FitnesEntities1())
                {
                    var clientToDelete = context.Clients.Find(SelectedClient.ID_Clients);
                    if (clientToDelete != null)
                    {
                        context.Clients.Remove(clientToDelete);
                        context.SaveChanges();

                        // Удаление из DataGrid
                        Clients.Remove(SelectedClient);
                        MessageBox.Show("Клиент успешно удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении клиента: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBoxCompanyName.Text = null;
            TextBoxPhoneNumber.Text = null;
            TextBoxAddress.Text = null;
            TextBoxEmail.Text = null;
            TextBoxContactPersonName.Text = null;
            TextBoxContactPersonSurname.Text = null;
            TextBoxContactPersonMiddlename.Text = null;
            TextBoxContractNumber.Text = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }
    }
}