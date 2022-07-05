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
    /// Interaction logic for DoctorPageViewMedicalRecord.xaml
    /// </summary>
    public partial class DoctorPageViewMedicalRecord : Page, INotifyPropertyChanged
    {
        private PatientController PatientController;
        private MedicalRecordController MedicalRecordController;
        private GuestMedicalRecordController GuestMedicalRecordController;
        private AllergiesController AllergiesController;
        public Model.MedicalRecord MedicalRecord;
        public GuestMedicalRecord GuestMedicalRecord;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public BindingList<Patient> patients;
        public BindingList<String> allergies;
        private static DoctorPageViewMedicalRecord instance = null;

        public static DoctorPageViewMedicalRecord Instance(string languageCode)
        {
            if (instance == null)
            {
                instance = new DoctorPageViewMedicalRecord(languageCode);
            }
            return instance;
        }

        public DoctorPageViewMedicalRecord(string languageCode)
        {
            InitializeComponent();
            this.DataContext = this;
            InitializeControllers();
            SwitchLanguage(languageCode);
            InitializeDataGrid();
        }
        private void InitializeControllers()
        {
            var app = Application.Current as App;
            PatientController = app.PatientController;
            MedicalRecordController = app.MedicalRecordController;
            GuestMedicalRecordController = app.GuestMedicalRecordController;
            AllergiesController = app.AllergiesController;
        }

        private void InitializeDataGrid()
        {
            var allPatients = PatientController.ReadAll();
            patients = new BindingList<Patient>(allPatients);
            PatientGrid.ItemsSource = patients;
        }

        private void Patients_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tbx = sender as TextBox;
            if (tbx.Text != "")
            {
                var filteredList = patients.Where(x => x.NameLastName.ToLower().Contains(tbx.Text.ToLower()));
                PatientGrid.ItemsSource = null;
                PatientGrid.ItemsSource = filteredList;
            }
            else
            {
                PatientGrid.ItemsSource = patients;
            }
        }
        private void InitializeFields()
        {
            Patient SelectedPatient = (Patient)PatientGrid.SelectedItem;
            if (SelectedPatient != null)
            {
                if (SelectedPatient.IsGuest)
                {
                    LoadGuestRecordFields(SelectedPatient);
                }
                else
                {
                    LoadRegularRecordFields(SelectedPatient);
                }
                LoadPatientAllergies(SelectedPatient);
            }
        }
        private void LoadPatientAllergies(Patient Patient)
        {
            var allAlergies = AllergiesController.PrintById(Patient.Id);
            allergies = new BindingList<string>(allAlergies);
            AllergyGrid.ItemsSource = allergies;

        }
        private void LoadGuestRecordFields(Patient Patient)
        {
            GuestMedicalRecord = GuestMedicalRecordController.ReadByPatientId(Patient.Id);
            NameBlock.Text = GuestMedicalRecord.Patient.NameLastName;
            UmcnBlock.Text = GuestMedicalRecord.Umcn;
            ParentBlock.Text = "---";
            BloodTypeBlock.Text = GuestMedicalRecord.BloodType.ToString();
            AddresBlock.Text = "---";

        }
        private void LoadRegularRecordFields(Patient Patient)
        {
            MedicalRecord = MedicalRecordController.ReadByPatientId(Patient.Id);
            NameBlock.Text = MedicalRecord.Patient.NameLastName;
            UmcnBlock.Text = MedicalRecord.Umcn;
            ParentBlock.Text = MedicalRecord.ParentName;
            BloodTypeBlock.Text = MedicalRecord.BloodType.ToString();
            AddresBlock.Text = MedicalRecord.Address.ToString();

        }

        private void PatientGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            InitializeFields();
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
