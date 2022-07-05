using Controller;
using Dto;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for PatientHomePage.xaml
    /// </summary>
    public partial class PatientHomePage : Window
    {
        public AppointmentController AppointmentController;
        public PatientController PatientController;
        public BindingList<Appointment> PatientAppointments;
        private readonly LoggedInController LoggedInController;
        public AnswerForAppointmentController AnswerForAppointmentController;
        public MaliciouslyPatientController MaliciouslyPatientController;
        private Thread Thread;

        public User User { get; }

       
        public PatientHomePage(User user)
        {
            InitializeComponent();
            Thread = new Thread(Notification);
            Thread.Start();
            var app = Application.Current as App;
            AnswerForAppointmentController = app.AnswerForAppointmentController;
            MaliciouslyPatientController = app.MaliciouslyPatientController;
            AppointmentController = app.AppointmentController;
            PatientController = app.PatientController;
            LoggedInController = app.LoggedInController;
            User = user;

            
            
            InitializeAppointmentList();
            appointmentList.ItemsSource = PatientAppointments;
        }
        
        private void isPatientMalicious()
        {
            bool isMalicious = MaliciouslyPatientController.IsPatientMaliciously(User.Id);
            if (isMalicious)
            {
                LoggedInController.Delete(User.Id);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }


        private void InitializeAppointmentList()
        {
           // thisTimer = new Timer(new TimerCallback(TherapyNotification), null, 1000, 60000);
            var allAppointments = AppointmentController.ReadByPatientId(User.Id);
            PatientAppointments = new BindingList<Appointment>(allAppointments);
        }


        private void AddAppointmentPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = PatientController.ReadById(User.Id);
            AppointmentCreatePatient appointmentCreatePatient = new AppointmentCreatePatient(patient);
            appointmentCreatePatient.Show();
            this.Close();

        }
        
        public bool IsAvailableEdit(Appointment selectedAppointment)
        {
            DateTime StartTime = selectedAppointment.StartTime;
            DateTime now = DateTime.Now.AddDays(2);

            int isAfter = DateTime.Compare(StartTime, now);
            return isAfter < 0;
        }

        private void EditAppointmentPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = PatientController.ReadById(User.Id);
            Appointment SelectedAppointment = (Appointment)appointmentList.SelectedItem;

            bool AvailableEdit = IsAvailableEdit(SelectedAppointment);

            if (!AvailableEdit == false)
            {
                MessageBox.Show("Nije moguce menjati odabrani pregled");
            }
            else {
                CrateEditAppointmentView(SelectedAppointment, patient);
            }
        }

            private void CrateEditAppointmentView(Appointment SelectedAppointment,Patient patient)
            {
                AppointmentEditPatient appointmentEditPatient = new AppointmentEditPatient(SelectedAppointment, patient, false);
                appointmentEditPatient.Show();
                this.Close();
            }

            
        private void DeleteAppointmentPatient_Click(object sender, RoutedEventArgs e)
        {
            Appointment SelectedAppointment = (Appointment)appointmentList.SelectedItem;

            if (SelectedAppointment != null)
            {
                Patient patient = PatientController.ReadById(User.Id);
                AppointmentController.Delete(SelectedAppointment.Id);
                PatientAppointments.ResetBindings();
                MaliciouslyPatient maliciouslyPatient = new MaliciouslyPatient()
                {
                    Patient = patient,
                    EditTime = DateTime.Now
                };
                MaliciouslyPatientController.Create(maliciouslyPatient);
                if (MaliciouslyPatientController.IsPatientMaliciously(patient.Id))
                {
                    LoggedInController.Delete(User.Id);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    PatientHomePage patientHomePage = new PatientHomePage(User);
                    patientHomePage.Show();
                    this.Close();
                }
                
            }
        }

        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            LoggedInController.Delete(User.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SystemRecommendation_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = PatientController.ReadById(User.Id);
            SystemRecommendation systemRecommendationPage = new SystemRecommendation(patient);
            systemRecommendationPage.Show();
            this.Close();
        }

        

        private void Notification(object state)
        {
            while (true)
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    String notification = PatientController.CheckNotifications(User.Id);
                    if (notification != null)
                    {
                        MessageBox.Show("Popijte terapiju " + notification + " za 30 minuta!");
                    }
                }));
                Thread.Sleep(30000);
            }   
        }

        public void OnClose(object sender, CancelEventArgs e)
        {
            
        }

        private void evaluateHospital_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = PatientController.ReadById(User.Id);
            EvalueateHospitalPage page = new EvalueateHospitalPage(patient);
            page.Show();
            this.Close();
        }
        private void EvaluateAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)appointmentList.SelectedItem;
            AnswerForAppointment answer = AnswerForAppointmentController.ReadByAppointmentId(appointment.Id);
            if(answer == null)
            {
                ShowEvaluateAppointment(appointment);
            }
            else
            {
                MessageBox.Show("Vec ste ocenili ovaj pregled.");
            }

            }
            private void ShowEvaluateAppointment(Appointment appointment)
            {
                EvaluateAppointmentPage evaluateAppointmentPage = new EvaluateAppointmentPage(appointment);
                evaluateAppointmentPage.Show();
                this.Close();
        }
    }
}

