using Syncfusion.Drawing;
using Syncfusion.Licensing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fitnes
{
    public partial class AdminOrder : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Orders> _orders;
        private ObservableCollection<Clients> _clients;
        private ObservableCollection<Technique> _techniques;
        private ObservableCollection<OrderStatus> _orderStatuses;
        private ObservableCollection<Employees> _employees;
        private Orders _selectedOrder;

        public ObservableCollection<Orders> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public ObservableCollection<Clients> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
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

        public ObservableCollection<OrderStatus> OrderStatuses
        {
            get => _orderStatuses;
            set
            {
                _orderStatuses = value;
                OnPropertyChanged(nameof(OrderStatuses));
            }
        }

        public ObservableCollection<Employees> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public Orders SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
                if (_selectedOrder != null)
                {
                    TextBoxOrderNumber.Text = _selectedOrder.OrderNumber.ToString();
                    ComboBoxClients.SelectedValue = _selectedOrder.Clients_ID;
                    ComboBoxTechnique.SelectedValue = _selectedOrder.Technique_ID;
                    TextBoxDateOfIssue.Text = _selectedOrder.DateOfIssue;
                    TextBoxReturnDate.Text = _selectedOrder.ReturnDate;
                    TextBoxPrice.Text = _selectedOrder.Price.ToString();
                    ComboBoxOrderStatus.SelectedValue = _selectedOrder.OrderStatus_ID;
                    TextBoxRentalPeriod.Text = _selectedOrder.RentalPeriod;
                    ComboBoxEmployees.SelectedValue = _selectedOrder.Employees_ID;
                }
            }
        }

        public AdminOrder()
        {
            InitializeComponent();
            DataContext = this;
            LoadData();
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCfEx0Qnxbf1x1ZFNMYlpbQHdPIiBoS35Rc0ViW3dfeHZTQmRfVEFz");
        }

        private void LoadData()
        {
            try
            {
                using (var context = new FitnesEntities1())
                {
                    Orders = new ObservableCollection<Orders>(context.Orders.ToList());
                    Clients = new ObservableCollection<Clients>(context.Clients.ToList());
                    Techniques = new ObservableCollection<Technique>(context.Technique.ToList());
                    OrderStatuses = new ObservableCollection<OrderStatus>(context.OrderStatus.ToList());
                    Employees = new ObservableCollection<Employees>(context.Employees.ToList());

                    ComboBoxClients.ItemsSource = Clients;
                    ComboBoxTechnique.ItemsSource = Techniques;
                    ComboBoxOrderStatus.ItemsSource = OrderStatuses;
                    ComboBoxEmployees.ItemsSource = Employees;
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
            if (!ValidateInputs())
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                using (var context = new FitnesEntities1())
                {
                    var newOrder = new Orders
                    {
                        OrderNumber = int.Parse(TextBoxOrderNumber.Text),
                        Clients_ID = (int)ComboBoxClients.SelectedValue,
                        Technique_ID = (int)ComboBoxTechnique.SelectedValue,
                        DateOfIssue = TextBoxDateOfIssue.Text,
                        ReturnDate = TextBoxReturnDate.Text,
                        Price = decimal.Parse(TextBoxPrice.Text),
                        OrderStatus_ID = (int)ComboBoxOrderStatus.SelectedValue,
                        RentalPeriod = TextBoxRentalPeriod.Text,
                        Employees_ID = (int)ComboBoxEmployees.SelectedValue
                    };
                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                    Orders.Add(newOrder);
                    MessageBox.Show("Заказ успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    GenerateContract(newOrder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении заказа: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                    "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedOrder == null)
            {
                MessageBox.Show("Выберите заказ для редактирования!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!ValidateInputs())
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                using (var context = new FitnesEntities1())
                {
                    var orderToUpdate = context.Orders.Find(SelectedOrder.ID_Order);
                    if (orderToUpdate != null)
                    {
                        orderToUpdate.OrderNumber = int.Parse(TextBoxOrderNumber.Text);
                        orderToUpdate.Clients_ID = (int)ComboBoxClients.SelectedValue;
                        orderToUpdate.Technique_ID = (int)ComboBoxTechnique.SelectedValue;
                        orderToUpdate.DateOfIssue = TextBoxDateOfIssue.Text;
                        orderToUpdate.ReturnDate = TextBoxReturnDate.Text;
                        orderToUpdate.Price = decimal.Parse(TextBoxPrice.Text);
                        orderToUpdate.OrderStatus_ID = (int)ComboBoxOrderStatus.SelectedValue;
                        orderToUpdate.RentalPeriod = TextBoxRentalPeriod.Text;
                        orderToUpdate.Employees_ID = (int)ComboBoxEmployees.SelectedValue;
                        context.SaveChanges();
                        var index = Orders.IndexOf(SelectedOrder);
                        Orders[index] = orderToUpdate;
                        MessageBox.Show("Заказ успешно изменен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании заказа: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                    "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateInputs()
        {
            return !string.IsNullOrWhiteSpace(TextBoxOrderNumber.Text) &&
                   ComboBoxClients.SelectedValue != null &&
                   ComboBoxTechnique.SelectedValue != null &&
                   !string.IsNullOrWhiteSpace(TextBoxDateOfIssue.Text) &&
                   !string.IsNullOrWhiteSpace(TextBoxReturnDate.Text) &&
                   !string.IsNullOrWhiteSpace(TextBoxPrice.Text) &&
                   ComboBoxOrderStatus.SelectedValue != null &&
                   !string.IsNullOrWhiteSpace(TextBoxRentalPeriod.Text) &&
                   ComboBoxEmployees.SelectedValue != null;
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
            ClearInputs();
        }

        private void ClearInputs()
        {
            TextBoxOrderNumber.Text = null;
            ComboBoxClients.SelectedValue = null;
            ComboBoxTechnique.SelectedValue = null;
            TextBoxDateOfIssue.Text = null;
            TextBoxReturnDate.Text = null;
            TextBoxPrice.Text = null;
            ComboBoxOrderStatus.SelectedValue = null;
            TextBoxRentalPeriod.Text = null;
            ComboBoxEmployees.SelectedValue = null;
        }

        private void GenerateContract(Orders order)
        {
            if (order == null)
            {
                MessageBox.Show("Заказ не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string contractsFolderPath = Path.Combine(desktopPath, "Договора");
            if (!Directory.Exists(contractsFolderPath))
            {
                Directory.CreateDirectory(contractsFolderPath);
            }
            string contractFileName = $"Договор_Аренды_{order.ID_Order}.pdf";
            string contractFilePath = Path.Combine(contractsFolderPath, contractFileName);

            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                string fontPath = @"C:\Windows\Fonts\times.ttf";
                if (!File.Exists(fontPath))
                {
                    MessageBox.Show("Шрифт Times New Roman не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                float fontSize = 12f;
                PdfTrueTypeFont font = new PdfTrueTypeFont(fontPath, fontSize);
                PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);
                float y = 20;
                float lineHeight = font.MeasureString("A").Height + 2;
                DrawCenteredText(graphics, "ДОГОВОР АРЕНДЫ", font, ref y, lineHeight);

                var selectedClient = ComboBoxClients.SelectedItem as Clients;
                var selectedTechnique = ComboBoxTechnique.SelectedItem as Technique;
                var selectedOrderStatus = ComboBoxOrderStatus.SelectedItem as OrderStatus;

                if (selectedClient != null)
                {
                    DrawText(graphics, $"Клиент {selectedClient.CompanyName}", font, ref y, lineHeight);
                }
                else
                {
                    DrawText(graphics, "Клиент: Не указан", font, ref y, lineHeight);
                }

                if (selectedTechnique != null)
                {
                    DrawText(graphics, $"Оборудование {selectedTechnique.TechniqueName}", font, ref y, lineHeight);
                }
                else
                {
                    DrawText(graphics, "Оборудование: Не указано", font, ref y, lineHeight);
                }

                DrawText(graphics, $"Дата аренды: {TextBoxDateOfIssue.Text}", font, ref y, lineHeight);
                DrawText(graphics, $"Дата возврата: {TextBoxReturnDate.Text}", font, ref y, lineHeight);
                DrawText(graphics, $"Сумма аренды: {TextBoxPrice.Text} руб.", font, ref y, lineHeight);

                if (selectedOrderStatus != null)
                {
                    DrawText(graphics, $"Статус аренды: {selectedOrderStatus.OrderStatus1}", font, ref y, lineHeight);
                }
                else
                {
                    DrawText(graphics, "Статус аренды: Не указан", font, ref y, lineHeight);
                }


                using (FileStream stream = new FileStream(contractFilePath, FileMode.Create, FileAccess.Write))
                {
                    document.Save(stream);
                }
                document.Close();
                MessageBox.Show($"Договор успешно создан: {contractFilePath}");
            }
        }

        private void DrawCenteredText(PdfGraphics graphics, string text, PdfTrueTypeFont font, ref float y, float lineHeight)
        {
            float headerWidth = font.MeasureString(text).Width;
            float pageWidth = graphics.ClientSize.Width;
            float xPosition = (pageWidth - headerWidth) / 2;
            graphics.DrawString(text, font, PdfBrushes.Black, new PointF(xPosition, y));
            y += lineHeight * 2;
        }

        private void DrawText(PdfGraphics graphics, string text, PdfTrueTypeFont font, ref float y, float lineHeight)
        {
            graphics.DrawString(text, font, PdfBrushes.Black, new PointF(20, y));
            y += lineHeight;
        }
    }
}