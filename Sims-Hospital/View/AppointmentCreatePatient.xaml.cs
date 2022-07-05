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
    /// Interaction logic for AppointmentCreatePatient.xaml
    /// </summary>
    public partial class AppointmentCreatePatient : Window
    {
        private  AppointmentController AppointmentController;
        private PatientController PatientController;
        private RoomController RoomController;
        private DoctorController DoctorController;
        private LoggedInController LoggedInController;
        public List<string> PriorityCollection { get; set; }
        public List<Doctor> Doctors { get; set; }
        public readonly Patient patient;

        public AppointmentCreatePatient(Patient patient)
        {
            InitializeComponent();
            var app = Application.Current as App;
            AppointmentController = app.AppointmentController;
            PatientController = app.PatientController;
            DoctorController = app.DoctorController;
            RoomController = app.RoomController;
            LoggedInController = app.LoggedInController;
            this.patient = patient;

            
            datePicker.DisplayDateStart= DateTime.Now;
            // Proveriti kako ispisati lekara preko comboBox-a
            DoctorsComboBoxInitialization();
            //this.appPatController = appPatController;
        }

        

        private void DoctorsComboBoxInitialization()
        {
            Doctors = DoctorController.ReadAllNotSpecialist();
//            

            doctorComboBox.ItemsSource = Doctors;
            doctorComboBox.DisplayMemberPath = "NameLastName";
            doctorComboBox.SelectedIndex = 0;
        }
        private DateTime MakeTime(DateTime dateTime, int hours, int minutes)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hours, minutes, 0);
        }
        private void SaveAppointmentButton_Click(object sender, RoutedEventArgs e)
        {

            DateTime now = DateTime.Now;
            DateTime newApp = (DateTime)datePicker.SelectedDate;
            int res2 = DateTime.Compare(now, newApp);//treba biti < 0 
            if (Int32.Parse(timeTextHour.Text) > 21 || Int32.Parse(timeTextHour.Text) < 8 || Int32.Parse(timeTextMinutes.Text) > 59 || Int32.Parse(timeTextMinutes.Text) < 0)
            {
                MessageBox.Show("Vreme je lose uneto");
            }
            else if (res2 > 0)
            {
                MessageBox.Show("Trazeni datum nije moguce odabrati");
            }
            else
            {

                CreateAppointmentPatientDTO appointment = new CreateAppointmentPatientDTO();
                appointment.StartTime = MakeTime((DateTime)datePicker.SelectedDate, Int32.Parse(timeTextHour.Text), Int32.Parse(timeTextMinutes.Text));
                appointment.Doctor = (Doctor)doctorComboBox.SelectedItem;
                appointment.Patient = patient;
                appointment.Priority = "Termin";


                AppointmentController.CreateByPatient(appointment);

                PatientHomePage patientHomePage = new PatientHomePage(patient);
                patientHomePage.Show();
                this.Close();
            }
        }

        private void logoutUser_Click(object sender, RoutedEventArgs e)
        {
            LoggedInController.Delete(patient.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
