using Syncfusion.Drawing;
using Syncfusion.Licensing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fitnes
{
    public partial class AdminOrder : Window
    {
        private FitnesEntities1 _context = new FitnesEntities1(); 

        public AdminOrder()
        {
            InitializeComponent();
            LoadData();
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCfEx0Qnxbf1x1ZFNMYlpbQHdPIiBoS35Rc0ViW3dfeHZTQmRfVEFz");
        }

        private void LoadData()
        {
            try
            {
                
                _context.Orders.Load();
                _context.Clients.Load(); 
                _context.Technique.Load(); 
                _context.OrderStatus.Load();
                _context.Employees.Load(); 

                dgrdOrders.ItemsSource = _context.Orders.Local; 
                ComboBoxClients.ItemsSource = _context.Clients.Local; 
                ComboBoxTechnique.ItemsSource = _context.Technique.Local; 
                ComboBoxOrderStatus.ItemsSource = _context.OrderStatus.Local; 
                ComboBoxEmployees.ItemsSource = _context.Employees.Local; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных");
                return;
            }

            try
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

                _context.Orders.Add(newOrder); 
                _context.SaveChanges(); 

                LoadData(); 
                ClearFields(); 
                MessageBox.Show("Заказ успешно добавлен!", "Успех");
                GenerateContract(newOrder); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении заказа: {ex.Message}");
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdOrders.SelectedItem is Orders selectedOrder)
            {
                if (!ValidateInputs())
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных");
                    return;
                }

                try
                {
                    
                    selectedOrder.OrderNumber = int.Parse(TextBoxOrderNumber.Text);
                    selectedOrder.Clients_ID = (int)ComboBoxClients.SelectedValue;
                    selectedOrder.Technique_ID = (int)ComboBoxTechnique.SelectedValue;
                    selectedOrder.DateOfIssue = TextBoxDateOfIssue.Text;
                    selectedOrder.ReturnDate = TextBoxReturnDate.Text;
                    selectedOrder.Price = decimal.Parse(TextBoxPrice.Text);
                    selectedOrder.OrderStatus_ID = (int)ComboBoxOrderStatus.SelectedValue;
                    selectedOrder.RentalPeriod = TextBoxRentalPeriod.Text;
                    selectedOrder.Employees_ID = (int)ComboBoxEmployees.SelectedValue;

                    _context.SaveChanges(); 
                    LoadData(); 
                    MessageBox.Show("Заказ успешно изменен!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании заказа: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования!", "Ошибка");
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
        private void dgrdOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgrdOrders.SelectedItem is Orders selectedOrder)
            {
                
                TextBoxOrderNumber.Text = selectedOrder.OrderNumber.ToString();
                ComboBoxClients.SelectedValue = selectedOrder.Clients_ID;
                ComboBoxTechnique.SelectedValue = selectedOrder.Technique_ID;
                TextBoxDateOfIssue.Text = selectedOrder.DateOfIssue;
                TextBoxReturnDate.Text = selectedOrder.ReturnDate;
                TextBoxPrice.Text = selectedOrder.Price.ToString();
                ComboBoxOrderStatus.SelectedValue = selectedOrder.OrderStatus_ID;
                TextBoxRentalPeriod.Text = selectedOrder.RentalPeriod;
                ComboBoxEmployees.SelectedValue = selectedOrder.Employees_ID;
            }
        }

        private void ClearFields()
        {
            
            TextBoxOrderNumber.Clear();
            ComboBoxClients.SelectedIndex = -1;
            ComboBoxTechnique.SelectedIndex = -1;
            TextBoxDateOfIssue.Clear();
            TextBoxReturnDate.Clear();
            TextBoxPrice.Clear();
            ComboBoxOrderStatus.SelectedIndex = -1;
            TextBoxRentalPeriod.Clear();
            ComboBoxEmployees.SelectedIndex = -1;
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

        private void GenerateContract(Orders order)
        {
            if (order == null)
            {
                MessageBox.Show("Заказ не найден!", "Ошибка");
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
                    MessageBox.Show("Шрифт Times New Roman не найден!", "Ошибка");
                    return;
                }
                float fontSize = 12f;
                PdfTrueTypeFont font = new PdfTrueTypeFont(fontPath, fontSize);
                PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);
                float y = 20;
                float lineHeight = font.MeasureString("A").Height + 2;

                
                DrawCenteredText(graphics, "ДОГОВОР АРЕНДЫ", font, ref y, lineHeight);

                
                var client = _context.Clients.Find(order.Clients_ID);
                if (client != null)
                {
                    DrawText(graphics, $"Клиент: {client.CompanyName}", font, ref y, lineHeight);
                }
                else
                {
                    DrawText(graphics, "Клиент: Не указан", font, ref y, lineHeight);
                }

                
                var technique = _context.Technique.Find(order.Technique_ID);
                if (technique != null)
                {
                    DrawText(graphics, $"Оборудование: {technique.TechniqueName}", font, ref y, lineHeight);
                }
                else
                {
                    DrawText(graphics, "Оборудование: Не указано", font, ref y, lineHeight);
                }

                
                DrawText(graphics, $"Дата аренды: {order.DateOfIssue}", font, ref y, lineHeight);
                DrawText(graphics, $"Дата возврата: {order.ReturnDate}", font, ref y, lineHeight);

                
                DrawText(graphics, $"Сумма аренды: {order.Price} руб.", font, ref y, lineHeight);

                
                var orderStatus = _context.OrderStatus.Find(order.OrderStatus_ID);
                if (orderStatus != null)
                {
                    DrawText(graphics, $"Статус аренды: {orderStatus.OrderStatus1}", font, ref y, lineHeight);
                }
                else
                {
                    DrawText(graphics, "Статус аренды: Не указан", font, ref y, lineHeight);
                }

                
                var employee = _context.Employees.Find(order.Employees_ID);
                if (employee != null)
                {
                    DrawText(graphics, $"Сотрудник: {employee.EmployeeName}", font, ref y, lineHeight);
                }
                else
                {
                    DrawText(graphics, "Сотрудник: Не указан", font, ref y, lineHeight);
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