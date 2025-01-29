using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fitnes
{
    public partial class AdminTechnique : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Technique> _techniques;
        private ObservableCollection<States> _statesList;
        private Technique _selectedTechnique;

        public ObservableCollection<Technique> Techniques
        {
            get => _techniques;
            set
            {
                _techniques = value;
                OnPropertyChanged(nameof(Techniques));
            }
        }

        public ObservableCollection<States> StatesList
        {
            get => _statesList;
            set
            {
                _statesList = value;
                OnPropertyChanged(nameof(StatesList));
            }
        }

        public Technique SelectedTechnique
        {
            get => _selectedTechnique;
            set
            {
                _selectedTechnique = value;
                OnPropertyChanged(nameof(SelectedTechnique));
                if (_selectedTechnique != null)
                {
                    TextBoxTechnicianNumber.Text = _selectedTechnique.TechnicianNumber;
                    TextBoxTechniqueName.Text = _selectedTechnique.TechniqueName;
                    TextBoxTechniqueModel.Text = _selectedTechnique.TechniqueModel;
                    TextBoxYearOfManufacture.Text = _selectedTechnique.YearOfManufacture;
                    TextBoxRentalCost.Text = _selectedTechnique.RentalCost.ToString();
                    ComboBoxState.SelectedValue = _selectedTechnique.State_ID;
                }
            }
        }

        public AdminTechnique()
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
                    Techniques = new ObservableCollection<Technique>(context.Technique.Include(t => t.States).ToList());

                    StatesList = new ObservableCollection<States>(context.States.ToList());

                    ComboBoxState.ItemsSource = StatesList;
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
                if (string.IsNullOrWhiteSpace(TextBoxTechnicianNumber.Text) || string.IsNullOrWhiteSpace(TextBoxTechniqueName.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxTechniqueModel.Text) || string.IsNullOrWhiteSpace(TextBoxYearOfManufacture.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxRentalCost.Text) || ComboBoxState.SelectedValue == null)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new FitnesEntities1())
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

                    Techniques.Add(newTechnique);
                    MessageBox.Show("Техника успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении техники: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTechnique == null)
            {
                MessageBox.Show("Выберите технику для редактирования!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxTechnicianNumber.Text) || string.IsNullOrWhiteSpace(TextBoxTechniqueName.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxTechniqueModel.Text) || string.IsNullOrWhiteSpace(TextBoxYearOfManufacture.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxRentalCost.Text) || ComboBoxState.SelectedValue == null)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var context = new FitnesEntities1())
                {
                    var techniqueToUpdate = context.Technique.Find(SelectedTechnique.ID_Technique);
                    if (techniqueToUpdate != null)
                    {
                        techniqueToUpdate.TechnicianNumber = TextBoxTechnicianNumber.Text;
                        techniqueToUpdate.TechniqueName = TextBoxTechniqueName.Text;
                        techniqueToUpdate.TechniqueModel = TextBoxTechniqueModel.Text;
                        techniqueToUpdate.YearOfManufacture = TextBoxYearOfManufacture.Text;
                        techniqueToUpdate.RentalCost = decimal.Parse(TextBoxRentalCost.Text);
                        techniqueToUpdate.State_ID = (int)ComboBoxState.SelectedValue;

                        context.SaveChanges();

                        var index = Techniques.IndexOf(SelectedTechnique);
                        Techniques[index] = techniqueToUpdate;
                        MessageBox.Show("Техника успешно изменена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании техники: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка редактирования", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTechnique == null)
            {
                MessageBox.Show("Выберите технику для удаления!", "Ошибка выбора", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new FitnesEntities1())
                {
                    var techniqueToDelete = context.Technique.Find(SelectedTechnique.ID_Technique);
                    if (techniqueToDelete != null)
                    {
                        context.Technique.Remove(techniqueToDelete);
                        context.SaveChanges();

                        Techniques.Remove(SelectedTechnique);
                        MessageBox.Show("Техника успешно удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении техники: {ex.Message}\n\nПодробности:\n{ex.InnerException?.Message}",
                                "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            TextBoxTechnicianNumber.Text = null;
            TextBoxTechniqueName.Text = null;
            TextBoxTechniqueModel.Text = null;
            TextBoxYearOfManufacture.Text = null;
            TextBoxRentalCost.Text = null;
            ComboBoxState.SelectedValue = null;
        }
    }
}