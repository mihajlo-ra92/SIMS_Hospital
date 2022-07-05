using Controller;
using Dto;
using Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PatientEdit.xaml
    /// </summary>
    public partial class PatientEdit : Window
    {
        public List<string> GenderCollection { get; set; }
        public Patient Patient { get; set; }
        public User User { get; }

        private readonly PatientController patController;
        private readonly LoggedInController loggedInController;

        public PatientEdit(Patient patient, User user)
        {
            InitializeComponent();

            GenderComboBoxInitialization();

            Patient = patient;
            User = user;
            InitializeFields();

            var app = Application.Current as App;
            this.patController = app.PatientController;
            loggedInController = app.LoggedInController;
        }

        private void InitializeFields()
        {
            nameText.Text = Patient.Name;
            lastNameText.Text = Patient.LastName;
            usernameText.Text = Patient.Username;
            emailText.Text = Patient.Email;
            passwordText.Text = Patient.Password;
            datePicker.SelectedDate = Patient.BirthDate;
            genderComboBox.SelectedValue = ConvertGenderToString(Patient.Gender);
            guestCheckBox.IsChecked = Patient.IsGuest;

        }

        private string ConvertGenderToString(Gender gender)
        {
            if (gender == Gender.Female)
            {
                return "Zensko";
            }
            return "Musko";
        }

        private void GenderComboBoxInitialization()
        {
            GenderCollection = new List<string>()
            {
                "Zensko",
                "Musko"
            };

            DataContext = this;
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
            EditPatientDTO editPatientDTO = new EditPatientDTO()
            {
                Id = Patient.Id,
                Name = nameText.Text,
                LastName = lastNameText.Text,
                Username = usernameText.Text,
                Email = emailText.Text,
                Password = passwordText.Text,
                BirthDate = datePicker.DisplayDate,
                Gender = ConvertStringToGender(genderComboBox.SelectedItem.ToString()),
                IsGuest = guestCheckBox.IsChecked.Value
            };

            patController.Edit(editPatientDTO);
            
            this.Close();
            SecretaryHomePage secretaryHomePage = new SecretaryHomePage(User);
            secretaryHomePage.Show();
        }

        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            loggedInController.Delete(Patient.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
