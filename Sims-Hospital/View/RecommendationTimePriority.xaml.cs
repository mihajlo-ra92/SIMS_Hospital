using System;
using Model;
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
using Controller;
using System.ComponentModel;
using Dto;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for RecommendationTimePriority.xaml
    /// </summary>
    public partial class RecommendationTimePriority : Window
    {
        public DoctorController DoctorController;
        private readonly LoggedInController loggedInController;
        public AppointmentController AppointmentController;

        public Patient Patient;
        public DateTime DateTime;
        public Doctor Doctor;
        public BindingList<Doctor> Doctors;

        public RecommendationTimePriority(Patient patient,Doctor doctor,DateTime time)
        {
            InitializeComponent();
            var app = Application.Current as App;
            DoctorController = app.DoctorController;
            loggedInController = app.LoggedInController;
            AppointmentController = app.AppointmentController;

            Patient = patient;
            DateTime = time;
            Doctor = doctor;
            InitializeDoctorList();
            doctorList.ItemsSource = Doctors;
        }


        private void InitializeDoctorList()
        {
            if(Doctor.isSpecialist == false)
            {
                var AllNotSpecialist = DoctorController.ReadAllNotSpecialist();
                Doctors = new BindingList<Doctor>(AllNotSpecialist);
            }
            else
            {
                var allSpecialist = DoctorController.ReadAllSpecialist(Doctor);
                Doctors = new BindingList<Doctor>(allSpecialist);
            }
        }
        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            loggedInController.Delete(Patient.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void DoctorList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CreateAppointmentPatientDTO appointmentDTO = new CreateAppointmentPatientDTO();
            appointmentDTO.Patient = Patient;
            appointmentDTO.Doctor = (Doctor)doctorList.SelectedItem;
            appointmentDTO.StartTime = DateTime.AddHours(8);
            appointmentDTO.Priority = "Termin";

            AppointmentController.CreateByPatient(appointmentDTO);

            PatientHomePage patientHomePage = new PatientHomePage(Patient);
            patientHomePage.Show();
            this.Close();

        }
    }
}
