using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for DoctorPageMedicineList.xaml
    /// </summary>
    public partial class DoctorPageMedicineListMVVM : Page, INotifyPropertyChanged
    {
        public MedicineController MedicineController;
        public DoctorController DoctorController;

        public BindingList<Medicine> medicines;
        public BindingList<string> ingredients;
        private static DoctorPageMedicineListMVVM instance = null;

        public event PropertyChangedEventHandler? PropertyChanged;

        public static DoctorPageMedicineListMVVM Instance(User User, string languageCode)
        {
            if (instance == null)
            {
                instance = new DoctorPageMedicineListMVVM(User, languageCode);
            }
            return instance;
        }
        public Doctor Doctor { get; set; }

        public DoctorPageMedicineListMVVM(User LogedUser, string languageCode)
        {
            InitializeComponent();
            this.DataContext = new MedicinesViewModel();
            //this.DataContext = this;
            //InitializeFields(LogedUser);
            //SwitchLanguage(languageCode);
            //InitializeMedicinesList();
        }
        private void InitializeFields(User LogedUser)
        {
            var app = Application.Current as App;
            MedicineController = app.MedicineController;
            DoctorController = app.DoctorController;
            Doctor = DoctorController.ReadById(LogedUser.Id);

        }
        private void InitializeMedicinesList()
        {
            var allMedicines = MedicineController.ReadAll();
            medicines = new BindingList<Medicine>(allMedicines);
            MedicineGrid.ItemsSource = medicines;
        }

        private void SearchMedicine_TextChanged(object sender, TextChangedEventArgs e)
        {
            var SearchBox = sender as TextBox;
            if (SearchBox.Text != "")
            {
                FilterGrid(SearchBox.Text);
            }
            else
            {
                MedicineGrid.ItemsSource = medicines;
            }
        }
        private void FilterGrid(string search)
        {
            List<Medicine> filteredByName = medicines.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            List<Medicine> filteredByCode = medicines.Where(x => x.Code.ToLower().Contains(search.ToLower())).ToList();
            var joinedList = filteredByName.Concat(filteredByCode);
            var filteredList = joinedList.GroupBy(x => x.Id).Select(y => y.First());
            MedicineGrid.ItemsSource = null;
            MedicineGrid.ItemsSource = filteredList;

        }

        private void InvalidateMedicine_Click(object sender, RoutedEventArgs e)
        {
            Medicine SelectedMedicine = (Medicine)MedicineGrid.SelectedItem;
            if (SelectedMedicine != null)
            {
                InvalidationRequestWindow invalidationRequestWindow = new InvalidationRequestWindow(SelectedMedicine);
                invalidationRequestWindow.Show();
            }
            else
            {
                var app = App.Current as App;
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("A medicine has not been selected!");
                }
                else
                {
                    MessageBox.Show("Nije izabran ni jedan lek!");
                }
            }
        }

        private void MedicineGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Medicine SelectedMedicine = (Medicine)MedicineGrid.SelectedItem;
            if (SelectedMedicine != null)
            {
                LoadMedicineInfo(SelectedMedicine);
            }
        }
        private void LoadMedicineInfo(Medicine Medicine)
        {
                InvalidationNote.Text = Medicine.Note;
                IngredientsList.ItemsSource = new BindingList<string>(Medicine.Ingredients);

        }
        public void SwitchLanguage(string languageCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            var app = App.Current as App;
            switch (languageCode)
            {
                case "en":
                    if (app.ThemeCode == "light")
                    {
                        dictionary.Source = new Uri("..\\StringResources.en.xaml", UriKind.Relative);

                    }
                    else
                    {
                        dictionary.Source = new Uri("..\\StringResources.en.dark.xaml", UriKind.Relative);
                    }
                    break;
                case "sr":
                    if (app.ThemeCode == "light")
                    {
                        dictionary.Source = new Uri("..\\StringResources.sr.xaml", UriKind.Relative);
                    }
                    else
                    {
                        dictionary.Source = new Uri("..\\StringResources.sr.dark.xaml", UriKind.Relative);
                    }
                    break;
                default:
                    dictionary.Source = new Uri("..\\StringResources.en.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dictionary);
        }
        public void SwitchTheme(string themeCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            var app = App.Current as App;
            switch (themeCode)
            {
                case "light":
                    if (app.LanguageCode == "en")
                    {
                        dictionary.Source = new Uri("..\\StringResources.en.xaml", UriKind.Relative);

                    }
                    else
                    {
                        dictionary.Source = new Uri("..\\StringResources.sr.xaml", UriKind.Relative);
                    }
                    break;
                case "dark":
                    if (app.LanguageCode == "en")
                    {
                        dictionary.Source = new Uri("..\\StringResources.en.dark.xaml", UriKind.Relative);
                    }
                    else
                    {
                        dictionary.Source = new Uri("..\\StringResources.sr.dark.xaml", UriKind.Relative);
                    }
                    break;
                default:
                    dictionary.Source = new Uri("..\\StringResources.en.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
