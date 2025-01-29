using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fitnes
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializePlaceholders();
        }

        private void InitializePlaceholders()
        {
            SetPlaceholder(EmailTextBox, "Почта");

            PasswordBox.GotFocus += (sender, e) => RemovePasswordPlaceholder();
            PasswordBox.LostFocus += (sender, e) => AddPasswordPlaceholder();
            PasswordBox.PasswordChanged += (sender, e) => HidePasswordPlaceholder();
        }

        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.Foreground = (Brush)new BrushConverter().ConvertFrom("#CCA15D"); 
            textBox.GotFocus += (sender, e) => RemoveText(textBox, placeholderText);
            textBox.LostFocus += (sender, e) => AddText(textBox, placeholderText);
        }

        private void RemoveText(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
            }
        }

        private void AddText(TextBox textBox, string placeholderText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
               
            }
        }

        private void RemovePasswordPlaceholder()
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
            PasswordBox.Focus();
        }

        private void AddPasswordPlaceholder()
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void HidePasswordPlaceholder()
        {
            if (!string.IsNullOrEmpty(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;


            if (email == "Почта" || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }

            using (var context = new FitnesEntities1())
            {
                var employee = context.Employees
                    .FirstOrDefault(emp => emp.Email == email && emp.Password == password);

                if (employee != null)
                {
                    MessageBox.Show($"Добро пожаловать, {employee.EmployeeName}!", "Успешная авторизация");


                    switch (employee.JobTitle.JobTitle1)
                    {
                        case "Администратор":
                            var adminWindow = new AdminWindow();
                            adminWindow.Show();
                            break;

                        case "Техник":
                            var technicianWindow = new TechnicianWindow();
                            technicianWindow.Show();
                            break;

                        case "Директор":
                            var directorWindow = new DirectorWindow();
                            directorWindow.Show();
                            break;

                        default:
                            MessageBox.Show("Роль пользователя не распознана!", "Ошибка");
                            break;
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный email или пароль!", "Ошибка авторизации");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}