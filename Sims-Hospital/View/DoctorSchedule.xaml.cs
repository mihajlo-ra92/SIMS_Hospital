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
    /// Interaction logic for DoctorSchedule.xaml
    /// </summary>
    public partial class DoctorSchedule : Window
    {
        public DoctorSchedule()
        {
            InitializeComponent();
        }

        private void ShowMedicalCard_Click(object sender, RoutedEventArgs e)
        {
            //Appointment SelectedAppointment = (Appointment)appointmentsList.SelectedItem;
            //PatientMedicalCard patientMedicalCard = new PatientMedicalCard(SelectedAppointment.Patient);
            //patientMedicalCard.Show();
        }
    }
}
