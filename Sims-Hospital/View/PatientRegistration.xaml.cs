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

    public partial class PatientRegistration : Window
    {
        private readonly LoggedInController loggedInController;

        public List<string> GenderCollection { get; set; }
        public User User { get; }

        public PatientRegistration(User user)
        {
            InitializeComponent();

            GenderComboBoxInitialization();
            User = user;
            var app = Application.Current as App;
            loggedInController = app.LoggedInController;
        }

        private void GenderComboBoxInitialization()
        {
            GenderCollection = new List<string>()
            {
                "Zensko",
                "Musko"
            };

            DataContext = this;
            genderComboBox.SelectedIndex = 0;
        }

        private Gender ConvertStringToGender(string gender)
        {
            if (gender == "Zensko")
            {
                return Gender.Female;
            }
            return Gender.Male;
        }

        private void SavePatientButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePatientDTO patient = new CreatePatientDTO()
            {
                Name = nameText.Text,
                LastName = lastNameText.Text,
                Username = usernameText.Text,
                Email = emailText.Text,
                Password = passwordText.Text,
                BirthDate = datePicker.DisplayDate,
                Gender = ConvertStringToGender(genderComboBox.SelectedItem.ToString()),
                Role = "Patient",
                IsGuest = guestCheckBox.IsChecked.Value
            };

            CreateAllergiesDTO createAllergiesDTO = new CreateAllergiesDTO()
            {
                Allergens = new List<string>(),
                Medicines = new List<Medicine>()
            };

            if (patient.IsGuest == true)
            {
                MedicalRecordGuest guest = new MedicalRecordGuest(patient, User, createAllergiesDTO);
                guest.Show();
            }else
            {
                MedicalRecord medicalRecord = new MedicalRecord(patient, User, createAllergiesDTO);
                medicalRecord.Show();
            }

            this.Close();
        }

        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            loggedInController.Delete(User.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
