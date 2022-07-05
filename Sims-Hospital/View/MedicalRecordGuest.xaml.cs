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

    public partial class MedicalRecordGuest : Window
    {
        private readonly GuestMedicalRecordController medController;
        private readonly PatientController patController;
        private readonly AllergiesController allergiesController;
        private readonly CreatePatientDTO PatientDTO;
        public List<string> BloodTypeCollection { get; set; }
        public CreateAllergiesDTO CreateAllergiesDTO { get; set; }
        public User User { get; }

        public MedicalRecordGuest(CreatePatientDTO patient, User user, CreateAllergiesDTO createAllergiesDTO)
        {
            InitializeComponent();
            BloodTypeComboBoxInitialization();

            this.PatientDTO = patient;
            User = user;
            CreateAllergiesDTO = createAllergiesDTO;

            var app = Application.Current as App;
            this.medController = app.GuestMedicalRecordController;
            this.patController = app.PatientController;
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

        private void SavePatientButton_Click(object sender, RoutedEventArgs e)
        {
            patController.Create(PatientDTO);

            Patient patient = patController.ReadByUsername(PatientDTO.Username);

            CreateAllergiesDTO.Patient = patient;
            allergiesController.Create(CreateAllergiesDTO);

            GuestMedicalRecordDTO medRecord = new()
            {
                Umcn = umcnText.Text,
                BloodType = ConvertFromStringToBloodType(bloodTypeComboBox.SelectedItem.ToString()),
                Allergies = allergiesController.ReadById(patient.Id),
                Patient = patient
            };

            medController.Create(medRecord);

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
