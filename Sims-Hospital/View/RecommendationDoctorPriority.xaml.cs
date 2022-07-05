using System;
using Model;
using Dto;
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

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for RecommendationDoctorPriority.xaml
    /// </summary>
    public partial class RecommendationDoctorPriority : Window
    {

        public AppointmentController AppointmentController;
        private readonly LoggedInController loggedInController;
        public Patient patient;
        public Doctor doctor;
        public DateTime start;
        public DateTime end;
        public BindingList<Appointment> patientAppointments;

        public RecommendationDoctorPriority(Patient patient,Doctor doctor,DateTime Start,DateTime End)
        {
            InitializeComponent();

            var app = Application.Current as App;
            AppointmentController = app.AppointmentController;
            loggedInController = app.LoggedInController;
            this.patient = patient;
            this.doctor = doctor;
            this.start = Start; 
            this.end = End;

            InitializeAppointmentList();
            appointmentList.ItemsSource = patientAppointments;
        }

        private void InitializeAppointmentList()
        {
            var allAppointments = AppointmentController.ReadRecommendation(patient, doctor.Id, start, end);
            if (allAppointments.Count != 0)
            {
                patientAppointments = new BindingList<Appointment>(allAppointments);
            }
            else
            {
                if (DateTime.Compare(DateTime.Now.AddDays(4), start) < 0)
                {
                     var allAppointments1 = AppointmentController.ReadRecommendation(patient, doctor.Id, start.AddDays(-4), start);
                     var allAppointments2 = AppointmentController.ReadRecommendation(patient, doctor.Id, end, end.AddDays(4));
                    patientAppointments = new BindingList<Appointment>(allAppointments1);
                    foreach (Appointment appointment in allAppointments2)
                    {
                        patientAppointments.Add(appointment);
                    }
                }
                else
                {
                    var allAppointments1 = AppointmentController.ReadRecommendation(patient, doctor.Id, DateTime.Now, start);
                    var allAppointments2 = AppointmentController.ReadRecommendation(patient, doctor.Id, end, end.AddDays(4));
                    patientAppointments = new BindingList<Appointment>(allAppointments1);
                    foreach(Appointment appointment in allAppointments2)
                    {
                        patientAppointments.Add(appointment);
                    }
                }
            }
            


        }

        private void appointmentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CreateAppointmentPatientDTO appointmentDTO = new CreateAppointmentPatientDTO();
            appointmentDTO.Patient = patient;
            appointmentDTO.Doctor = doctor;
            Appointment NewAppointment = (Appointment)appointmentList.SelectedItem;
            appointmentDTO.StartTime = NewAppointment.StartTime;
            appointmentDTO.Priority = "Lekar";
            AppointmentController.CreateByPatient(appointmentDTO);

            PatientHomePage patientHomePage = new PatientHomePage(patient);
            patientHomePage.Show();
            this.Close();
        }

        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            loggedInController.Delete(patient.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
