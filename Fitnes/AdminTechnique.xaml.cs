using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fitnes
{
    public partial class AdminTechnique : Window
    {
        private FitnesEntities1 context = new FitnesEntities1(); 

        public AdminTechnique()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                
                var techniques = context.Technique
                    .Include(t => t.States)
                    .ToList();

                dgrdTechnique.ItemsSource = techniques; 
                ComboBoxState.ItemsSource = context.States.ToList(); 
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
               
                var newTechnique = new Technique
                {
                    TechnicianNumber = TextBoxTechnicianNumber.Text,
                    TechniqueName = TextBoxTechniqueName.Text,
                    TechniqueModel = TextBoxTechniqueModel.Text,
                    YearOfManufacture = TextBoxYearOfManufacture.Text,
                    RentalCost = decimal.Parse(TextBoxRentalCost.Text),
                    State_ID = (int)ComboBoxState.SelectedValue
                };

                context.Technique.Add(newTechnique);
                context.SaveChanges(); 

                LoadData(); 
                ClearFields(); 
                MessageBox.Show("Техника успешно добавлена!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении техники: {ex.Message}");
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdTechnique.SelectedItem is Technique selectedTechnique)
            {
                try
                {
                   
                    selectedTechnique.TechnicianNumber = TextBoxTechnicianNumber.Text;
                    selectedTechnique.TechniqueName = TextBoxTechniqueName.Text;
                    selectedTechnique.TechniqueModel = TextBoxTechniqueModel.Text;
                    selectedTechnique.YearOfManufacture = TextBoxYearOfManufacture.Text;
                    selectedTechnique.RentalCost = decimal.Parse(TextBoxRentalCost.Text);
                    selectedTechnique.State_ID = (int)ComboBoxState.SelectedValue;

                    context.SaveChanges(); 
                    LoadData(); 
                    MessageBox.Show("Техника успешно изменена!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании техники: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите технику для редактирования!", "Ошибка");
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgrdTechnique.SelectedItem is Technique selectedTechnique)
            {
                try
                {
                    context.Technique.Remove(selectedTechnique);
                    context.SaveChanges(); 
                    LoadData(); 
                    MessageBox.Show("Техника успешно удалена!", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении техники: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите технику для удаления!", "Ошибка");
            }
        }

        private void dgrdTechnique_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgrdTechnique.SelectedItem is Technique selectedTechnique)
            {
                
                TextBoxTechnicianNumber.Text = selectedTechnique.TechnicianNumber;
                TextBoxTechniqueName.Text = selectedTechnique.TechniqueName;
                TextBoxTechniqueModel.Text = selectedTechnique.TechniqueModel;
                TextBoxYearOfManufacture.Text = selectedTechnique.YearOfManufacture;
                TextBoxRentalCost.Text = selectedTechnique.RentalCost.ToString();
                ComboBoxState.SelectedValue = selectedTechnique.State_ID;
            }
        }

        private void ClearFields()
        {
            
            TextBoxTechnicianNumber.Clear();
            TextBoxTechniqueName.Clear();
            TextBoxTechniqueModel.Clear();
            TextBoxYearOfManufacture.Clear();
            TextBoxRentalCost.Clear();
            ComboBoxState.SelectedIndex = -1;
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