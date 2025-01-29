using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows;
using Fitnes;
using System.Windows.Documents;
using System.Xml.Linq;
using System.Globalization;
using PdfSharp.Drawing;
using PdfSharp.Pdf;


namespace Fitnes
{
    public partial class DirectorWindowOtcheti : Window, INotifyPropertyChanged
    {
        private ObservableCollection<dynamic> _reportData;
        public ObservableCollection<dynamic> ReportData
        {
            get => _reportData;
            set
            {
                _reportData = value;
                OnPropertyChanged(nameof(ReportData));
            }
        }

        public DirectorWindowOtcheti()
        {
            InitializeComponent();
            DataContext = this;
            ReportData = new ObservableCollection<dynamic>();
        }
        private string _currentReportTitle;
        public string CurrentReportTitle
        {
            get => _currentReportTitle;
            set
            {
                _currentReportTitle = value;
                OnPropertyChanged(nameof(CurrentReportTitle));
            }
        }


        private void ComboBoxReports_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ComboBoxReports.SelectedItem == null) return;

            string selectedReport = (ComboBoxReports.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

            switch (selectedReport)
            {
                case "Доходы":
                    CurrentReportTitle = "Анализ Доходов";
                    LoadIncomeAnalysis();
                    break;
                case "Загрузка техники":
                    CurrentReportTitle = "Анализ Загрузки Техники";
                    LoadTechniqueLoadAnalysis();
                    break;
                case "Состояние парка":
                    CurrentReportTitle = "Анализ Состояния Парка";
                    LoadParkConditionAnalysis();
                    break;
                case "График техобслуживания":
                    CurrentReportTitle = "График Технического Обслуживания";
                    LoadMaintenanceScheduleAnalysis();
                    break;
            }
        }




        private void LoadIncomeAnalysis()
        {
            using (var context = new FitnesEntities1())
            {
                var incomeData = context.Orders
                    .GroupBy(o => o.Clients.CompanyName) 
                    .Select(g => new
                    {
                        Клиент = g.Key, 
                        Доходы = g.Sum(o => o.Price) 
                    })
                    .ToList();

                ReportData = new ObservableCollection<dynamic>(incomeData);
            }
        }

        private void LoadTechniqueLoadAnalysis()
        {
            using (var context = new FitnesEntities1())
            {
                var loadData = context.Orders
                    .AsEnumerable() 
                    .GroupBy(o => o.Technique.TechniqueName)
                    .Select(g => new
                    {
                        Техника = g.Key,
                        КоличествоЗаказов = g.Count(),
                        ОбщийПериодАренды = g.Sum(o => ExtractDaysFromRentalPeriod(o.RentalPeriod)) 
                    })
                    .ToList();

                ReportData = new ObservableCollection<dynamic>(loadData);
            }
        }

        private int ExtractDaysFromRentalPeriod(string rentalPeriod)
        {
            string digitsOnly = new string(rentalPeriod.Where(char.IsDigit).ToArray());

            if (int.TryParse(digitsOnly, out int days))
            {
                return days;
            }

          
            return 0;
        }

        private void LoadParkConditionAnalysis()
        {
            using (var context = new FitnesEntities1())
            {
                var parkConditionData = context.Technique
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

                ReportData = new ObservableCollection<dynamic>(parkConditionData);
            }
        }
        private void LoadMaintenanceScheduleAnalysis()
        {
            using (var context = new FitnesEntities1())
            {
                var maintenanceData = context.Maintenance
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

                ReportData = new ObservableCollection<dynamic>(maintenanceData);
            }
        }


        private void ButtonGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            string fileName = $"{CurrentReportTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"; 
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

                gfx.DrawString(CurrentReportTitle, fontTitle, XBrushes.Black,
                               new XRect(0, 20, page.Width, page.Height), XStringFormats.TopCenter);

                double yPosition = 50;

                var properties = ReportData.First().GetType().GetProperties();
                double xPosition = 20;
                double columnWidth = (page.Width - 40) / properties.Length;

                foreach (var prop in properties)
                {
                    gfx.DrawString(prop.Name, fontHeader, XBrushes.Black,
                                   new XRect(xPosition, yPosition, columnWidth, 20), XStringFormats.TopLeft);
                    xPosition += columnWidth;
                }

                yPosition += 20;

                foreach (var item in ReportData)
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

                MessageBox.Show($"Отчет успешно сохранен на рабочий стол: {fileName}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var directorWindow = new DirectorWindow();
            directorWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}