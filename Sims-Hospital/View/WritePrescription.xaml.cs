using Controller;
using Model;
using Dto;
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
using System.Windows.Shapes;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for WritePrescription.xaml
    /// </summary>
    public partial class WritePrescription : Window, INotifyPropertyChanged
    {
        private PrescriptionController PrescriptionController;
        private MedicineNotificationController MediicineNotificationController;
        private MedicineController MedicineController;
        private AllergiesController AllergiesController;
        public Prescription Prescription { get; set; }
        public Appointment Appointment;
        public BindingList<Medicine> medicines;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _medicineName;
        private string _medicineAmmount;
        private string _medicineTimesADay;
        private string _therapyDays;
        public string MedicineName
        {
            get
            {
                return _medicineName;
            }
            set
            {
                if (value != _medicineName)
                {
                    _medicineName = value;
                    OnPropertyChanged("MedicineName");
                }
            }
        }
        public string MedicineAmmount
        {
            get
            {
                return _medicineAmmount;
            }
            set
            {
                if (value != _medicineAmmount)
                {
                    _medicineAmmount = value;
                    OnPropertyChanged("MedicineAmmount");
                }
            }
        }
        public string MedicineTimesADay
        {
            get
            {
                return _medicineTimesADay;
            }
            set
            {
                if (value != _medicineTimesADay)
                {
                    _medicineTimesADay = value;
                    OnPropertyChanged("MedicineTimesADay");
                }
            }
        }
        public string TherapyDays
        {
            get
            {
                return _therapyDays;
            }
            set
            {
                if (value != _therapyDays)
                {
                    _therapyDays = value;
                    OnPropertyChanged("TherapyDays");
                }
            }
        }
        public WritePrescription(Appointment appointment, string languageCode)
        {
            InitializeComponent();
            this.DataContext = this;
            InitializeFields(appointment);
            SwitchLanguage(languageCode);
            InitializeMedicinesList();

        }
        private void InitializeFields(Appointment appointment)
        {
            var app = Application.Current as App;
            PrescriptionController = app.PrescriptionController;
            MedicineController = app.MedicineController;
            AllergiesController = app.AllergiesController;
            this.Appointment = appointment;
            this.Prescription = new Prescription();
            this.Prescription.Appointment = this.Appointment;
        }
        private void InitializeMedicinesList()
        {
            var allMedicines = MedicineController.ReadAll();
            medicines = new BindingList<Medicine>(allMedicines);
            MedicineGrid.ItemsSource = medicines;
        }
        private bool PatientAllergicToMedicine(Medicine Medicine)
        {
            PatientAllergies Allergy = AllergiesController.ReadByPatientId(Appointment.Patient.Id);
            return Allergy.Medicines.Contains(Medicine);

        }
        private bool PatientAllergicToIngredient(Medicine Medicine)
        {
            PatientAllergies Allergy = AllergiesController.ReadByPatientId(Appointment.Patient.Id);
            foreach (string ingredient in Medicine.Ingredients)
            {
                if (Allergy.Allergens.Contains(ingredient))
                    return true;
            }
            return false;
        }
        private void CreatePrescription(Medicine Medicine)
        {
            CreatePrescriptionDTO createPrescription = new CreatePrescriptionDTO();
            createPrescription.Appointment = this.Appointment;
            createPrescription.Patient = this.Appointment.Patient;
            createPrescription.StartDate = (DateTime)datePickerStart.SelectedDate;
            createPrescription.Medicine = Medicine.Name;
            createPrescription.TimesADay = int.Parse(MedicineTimesADay);
            DateTime date = (DateTime)datePickerStart.SelectedDate;
            createPrescription.EndDate = date.AddDays(Int32.Parse(TherapyDays));
            PrescriptionController.Create(createPrescription);
            this.Close();
        }
        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine SelectedMedicine = (Medicine)MedicineGrid.SelectedItem;
            if (SelectedMedicine != null)
            {
                if (!PatientAllergicToMedicine(SelectedMedicine) && !PatientAllergicToIngredient(SelectedMedicine))
                {
                    CreatePrescription(SelectedMedicine);
                }
                else
                {
                    if (PatientAllergicToMedicine(SelectedMedicine))
                    {
                        MessageBox.Show("Pacijent je alergican na lek!");
                    }
                    else
                    {
                        MessageBox.Show("Pacijent je alergican na sastojak leka");
                    }
                }
            }
        }
        private void SwitchLanguage(string languageCode)
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
    }
}
