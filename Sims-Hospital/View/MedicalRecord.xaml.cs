using Controller;
using Dto;
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
using System.Windows.Shapes;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for MedicalRecord.xaml
    /// </summary>
    public partial class MedicalRecord : Window
    {
        private readonly MedicalRecordController MedController;
        private readonly PatientController PatController;
        private readonly AllergiesController allergiesController;
        private readonly CreatePatientDTO Patient;
        public CreateAllergiesDTO CreateAllergiesDTO { get; set; }
        public List<string> BloodTypeCollection { get; set; }
        public Address address { get; set; }
        public User User { get; }

        public MedicalRecord(CreatePatientDTO patient, User user, CreateAllergiesDTO createAllergiesDTO)
        {
            InitializeComponent();
            BloodTypeComboBoxInitialization();

            this.Patient = patient;
            User = user;
            CreateAllergiesDTO = createAllergiesDTO;

            var app = Application.Current as App;
            this.MedController = app.MedicalRecordController;
            this.PatController = app.PatientController;
            this.allergiesController = app.AllergiesController;
        }

        private void BloodTypeComboBoxInitialization()
        {
            BloodTypeCollection = new List<string>()
            {
                "A+",
                "A-",
                "B+",
                "B-",
                "AB+",
                "AB-",
                "0+",
                "0-"
            };

            DataContext = this;
            bloodTypeComboBox.SelectedIndex = 0;
        }

        private void AddAllergiesButton_Click(object sender, RoutedEventArgs e)
        {
            Allergies allergies = new Allergies(CreateAllergiesDTO, false);
            allergies.Show();
        }

        private void AddAddressButton_Click(object sender, RoutedEventArgs e)
        {
            address = new Address();
            AddressDialog addressDialog = new AddressDialog(address);
            addressDialog.Show();
        }

        private void SavePatientButton_Click(object sender, RoutedEventArgs e)
        {
            PatController.Create(Patient);
            Patient patient = PatController.ReadByUsername(Patient.Username);

            CreateAllergiesDTO.Patient = patient;
            allergiesController.Create(CreateAllergiesDTO);

            MedicalRecordDTO recordDTO = new()
            {
                Umcn = umcnText.Text,
                Allergies = allergiesController.ReadById(patient.Id),
                ParentName = parentNameText.Text,
                BloodType = ConvertFromStringToBloodType(bloodTypeComboBox.SelectedItem.ToString()),
                Address = address,
                Patient = patient,
            };

            MedController.Create(recordDTO);
            SecretaryHomePage secretaryHomePage = new SecretaryHomePage(User);
            secretaryHomePage.Show();

            this.Close();
        }

        private BloodType ConvertFromStringToBloodType(string bloodType)
        {
            var dict = new Dictionary<string, BloodType>
            {
                {"A+", BloodType.A_Positive },
                {"A-", BloodType.A_Negative },
                {"B+", BloodType.B_Positive},
                {"B-", BloodType.B_Negative},
                {"AB+", BloodType.AB_Positive},
                {"AB-", BloodType.AB_Negative},
                {"0+", BloodType.Zero_Positive},
                {"0-", BloodType.Zero_Negative },
            };

            return dict[bloodType];
        }
    }
}
