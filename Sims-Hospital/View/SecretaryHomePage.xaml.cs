using Controller;
using DTO;
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
    /// Interaction logic for SecretaryHomePage.xaml
    /// </summary>
    public partial class SecretaryHomePage : Window
    {
        private PatientController patController;

        public BindingList<Patient> patients;
        private readonly LoggedInController loggedInController;
        private readonly GuestMedicalRecordController guestMedicalRecordController;
        private readonly MedicalRecordController medicalRecordController;

        public User User { get; set; }

        public SecretaryHomePage(User user)
        {
            InitializeComponent();

            InitializeController();

            InitializePatientsList();
            patientsList.ItemsSource = patients;
            User = user;
            var app = Application.Current as App;
            loggedInController = app.LoggedInController;
            guestMedicalRecordController = app.GuestMedicalRecordController;
            medicalRecordController = app.MedicalRecordController;
        }

        private void InitializeController()
        {
            var app = Application.Current as App;
            patController = app.PatientController;

        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            PatientRegistration registration = new PatientRegistration(User);
            registration.Show();
            this.Close();
        }

        private void InitializePatientsList()
        {
            patients?.Clear();

            var allPatients = patController.ReadAll();
            patients = new BindingList<Patient>(allPatients);
        }

        private void EditPatient_Click(object sender, RoutedEventArgs e)
        {
            PatientEdit patientEdit = new PatientEdit((Patient)patientsList.SelectedItem, User);
            patientEdit.Show();
            this.Close();
        }

        private void DeletePatient_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)patientsList.SelectedItem;
            patController.Delete(patient.Id);

            patients.ResetBindings();
        }

        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            loggedInController.Delete(User.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void EditAllergies_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)patientsList.SelectedItem;

            GuestMedicalRecord guestMedicalRecord;

            if (patient.IsGuest == true)
            {
                guestMedicalRecord = guestMedicalRecordController.ReadByPatientId(patient.Id);
            }else
            {
                guestMedicalRecord = medicalRecordController.ReadByPatientId(patient.Id);
            }

            PatientAllergies patientAllergies = guestMedicalRecord.Allergies;

            EditAllergiesDTO editAllergiesDTO = new EditAllergiesDTO() 
            {
                Id = patientAllergies.Id,
                Allergens = patientAllergies.Allergens,
                Medicines = patientAllergies.Medicines,
                Patient = patient,
            };

            Allergies allergies = new Allergies(editAllergiesDTO, true);
            allergies.Show();

        }

        private void EditAppointments_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient) patientsList.SelectedItem;

            PatientAppointments patientAppointments = new PatientAppointments(patient);
            patientAppointments.Show();
        }
    }
}
