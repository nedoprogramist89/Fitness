using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fitnes
{
    public partial class MainWindow : Window
    {
        FitnesEntities1 yp = new FitnesEntities1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Auth(object sender, RoutedEventArgs e)
        {
            var vxod = yp.Employees.ToList();
            bool avtoriz = false;

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            foreach (var v in vxod)
            {
                if (v.Email == EmailTextBox.Text && v.Password == PasswordBox.Password)
                {
                    avtoriz = true;

                    if (v.JobTitle_ID == 1)
                    {
                        AdminWindow admin = new AdminWindow();
                        admin.Show();
                        this.Close();
                    }
                    else if (v.JobTitle_ID == 2)
                    {
                        DirectorWindow direktor = new DirectorWindow();
                        direktor.Show();
                        this.Close();
                    }
                    else if (v.JobTitle_ID == 3)
                    {
                        TechnicianWindow technik = new TechnicianWindow();
                        technik.Show();
                        this.Close();
                    }

                    Close();
                    break;
                }
            }

            if (!avtoriz)
            {
                MessageBox.Show("Такого логина/пароля не существует. Попробуйте еще раз.");
                EmailTextBox.Text = null;
                PasswordBox.Password = null;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}