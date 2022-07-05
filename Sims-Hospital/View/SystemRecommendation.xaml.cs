using Controller;
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
    /// Interaction logic for SystemRecommendation.xaml
    /// </summary>
    public partial class SystemRecommendation : Window
    {
        public Patient Patient;
        public DoctorController doctorController;
        public LoggedInController loggedInController;
        public List<string> PriorityCollection { get; set; }
        public List<Doctor> Doctors { get; set; }

        public SystemRecommendation(Patient patient)
        {
            InitializeComponent();
            var app = Application.Current as App;
            doctorController = app.DoctorController;
            loggedInController = app.LoggedInController;
            Patient = patient;
            datePickerStart.DisplayDateStart = DateTime.Now.AddDays(1);
            datePickerEnd.DisplayDateStart = DateTime.Now.AddDays(2);
            PriortyComboBoxInitialization();
            DoctorsComboBoxInitialization();

        }
        private void PriortyComboBoxInitialization()
        {
            PriorityCollection = new List<string>()
            {
                "Lekar",
                "Termin"
            };

            DataContext = this;
            priorityComboBox.SelectedIndex = 0;
        }

        private void DoctorsComboBoxInitialization()
        {
            Doctors = doctorController.ReadAll();
            //            

            doctorComboBox.ItemsSource = Doctors;
            doctorComboBox.DisplayMemberPath = "NameLastName";
            doctorComboBox.SelectedIndex = 0;
        }

        private void RecommendationAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if(priorityComboBox.SelectedValue == "Lekar")
            {
                RecommendationDoctorPriority recommendationDoctorPriority   = new(Patient,(Doctor)doctorComboBox.SelectedItem,(DateTime)datePickerStart.SelectedDate, (DateTime)datePickerEnd.SelectedDate);
                recommendationDoctorPriority.Show();
                this.Close();
            }
            else
            {
                RecommendationTimePriority recommendationTimePriority = new RecommendationTimePriority(Patient, (Doctor)doctorComboBox.SelectedItem, (DateTime)datePickerStart.SelectedDate);
                recommendationTimePriority.Show();
                this.Close();
            }
        }


        private void logoutUser_Click(object sender, RoutedEventArgs e)
        {
            loggedInController.Delete(Patient.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
