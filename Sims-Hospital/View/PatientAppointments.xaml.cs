using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PatientAppointments.xaml
    /// </summary>
    public partial class PatientAppointments : Window
    {
        public Patient Patient { get; }
        ObservableCollection<Appointment> Appointments { get; set; }
        AppointmentController AppointmentController { get; set; }

        public PatientAppointments(Patient patient)
        {
            InitializeComponent();
            Patient = patient;

            var app = Application.Current as App;
            AppointmentController = app.AppointmentController;

            Appointments = new ObservableCollection<Appointment>(AppointmentController.ReadByPatientId(patient.Id));
            
            this.DataContext = this;
            dataGridAppointments.ItemsSource = Appointments;
        }

        private void EditAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = dataGridAppointments.SelectedItem as Appointment;

            if (appointment != null)
            {
                AppointmentEditPatient appointmentEditPatient = new AppointmentEditPatient(appointment, Patient, true);
                appointmentEditPatient.Show();
                this.Close();
            }
        }
    }
}
