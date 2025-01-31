using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Fitnes
{
    public partial class DirectorWindowOtcheti : Window
    {
        private FitnesEntities1 _context = new FitnesEntities1(); 
        private List<dynamic> _reportData;
        private string _currentReportTitle;

        public DirectorWindowOtcheti()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            
            _reportData = new List<dynamic>();
            dgrdReportData.ItemsSource = _reportData;
        }

        private void ComboBoxReports_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ComboBoxReports.SelectedItem == null) return;

            string selectedReport = (ComboBoxReports.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

            switch (selectedReport)
            {
                case "Доходы":
                    _currentReportTitle = "Анализ Доходов";
                    LoadIncomeAnalysis();
                    break;
                case "Загрузка техники":
                    _currentReportTitle = "Анализ Загрузки Техники";
                    LoadTechniqueLoadAnalysis();
                    break;
                case "Состояние парка":
                    _currentReportTitle = "Анализ Состояния Парка";
                    LoadParkConditionAnalysis();
                    break;
                case "График техобслуживания":
                    _currentReportTitle = "График Технического Обслуживания";
                    LoadMaintenanceScheduleAnalysis();
                    break;
            }
        }

        private void LoadIncomeAnalysis()
        {
            var incomeData = _context.Orders
                .GroupBy(o => o.Clients.CompanyName)
                .Select(g => new
                {
                    Клиент = g.Key,
                    Доходы = g.Sum(o => o.Price)
                })
                .ToList();

            _reportData = incomeData.Cast<dynamic>().ToList();
            dgrdReportData.ItemsSource = _reportData;
        }

        private void LoadTechniqueLoadAnalysis()
        {
            var loadData = _context.Orders
                .AsEnumerable()
                .GroupBy(o => o.Technique.TechniqueName)
                .Select(g => new
                {
                    Техника = g.Key,
                    КоличествоЗаказов = g.Count(),
                    ОбщийПериодАренды = g.Sum(o => ExtractDaysFromRentalPeriod(o.RentalPeriod))
                })
                .ToList();

            _reportData = loadData.Cast<dynamic>().ToList();
            dgrdReportData.ItemsSource = _reportData;
        }

        private int ExtractDaysFromRentalPeriod(string rentalPeriod)
        {
            string digitsOnly = new string(rentalPeriod.Where(char.IsDigit).ToArray());
            return int.TryParse(digitsOnly, out int days) ? days : 0;
        }

        private void LoadParkConditionAnalysis()
        {
            var parkConditionData = _context.Technique
                .AsEnumerable()
                .Select(t => new
                {
                    НазваниеТехники = t.TechniqueName,
                    Модель = t.TechniqueModel,
                    ГодВыпуска = t.YearOfManufacture,
                    Состояние = t.States.States1,
                    КоличествоЗаказов = t.Orders.Count(),
                    ПоследнееОбслуживание = t.Maintenance
                        .OrderByDescending(m => m.MaintenanceDate)
                        .Select(m => m.MaintenanceDate)
                        .FirstOrDefault()
                })
                .ToList();

            _reportData = parkConditionData.Cast<dynamic>().ToList();
            dgrdReportData.ItemsSource = _reportData;
        }

        private void LoadMaintenanceScheduleAnalysis()
        {
            var maintenanceData = _context.Maintenance
                .Include(m => m.MaintenanceStatus)
                .Include(m => m.Technique)
                .Select(m => new
                {
                    ДатаОбслуживания = m.MaintenanceDate,
                    ТипРаботы = m.TypeOfWork,
                    Статус = m.MaintenanceStatus.MaintenanceStatus1,
                    Техника = m.Technique.TechniqueName,
                })
                .ToList();

            _reportData = maintenanceData.Cast<dynamic>().ToList();
            dgrdReportData.ItemsSource = _reportData;
        }

        private void ButtonGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            string fileName = $"{_currentReportTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);

            try
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont fontTitle = new XFont("Times New Roman", 24);
                XFont fontHeader = new XFont("Times New Roman", 12);
                XFont fontData = new XFont("Times New Roman", 10);

                gfx.DrawString(_currentReportTitle, fontTitle, XBrushes.Black,
                               new XRect(0, 20, page.Width, page.Height), XStringFormats.TopCenter);

                double yPosition = 50;

                var properties = _reportData.First().GetType().GetProperties();
                double xPosition = 20;
                double columnWidth = (page.Width - 40) / properties.Length;

                foreach (var prop in properties)
                {
                    gfx.DrawString(prop.Name, fontHeader, XBrushes.Black,
                                   new XRect(xPosition, yPosition, columnWidth, 20), XStringFormats.TopLeft);
                    xPosition += columnWidth;
                }

                yPosition += 20;

                foreach (var item in _reportData)
                {
                    xPosition = 20;
                    foreach (var prop in item.GetType().GetProperties())
                    {
                        gfx.DrawString(prop.GetValue(item)?.ToString(), fontData, XBrushes.Black,
                                       new XRect(xPosition, yPosition, columnWidth, 20), XStringFormats.TopLeft);
                        xPosition += columnWidth;
                    }
                    yPosition += 20;
                }

                document.Save(filePath);
                MessageBox.Show($"Отчет успешно сохранен на рабочий стол: {fileName}", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var directorWindow = new DirectorWindow();
            directorWindow.Show();
            this.Close();
        }
    }
}