using Controller;
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
    /// Interaction logic for RoomSchedule.xaml
    /// </summary>
    public partial class RoomSchedule : Window
    {
        public AppointmentController AppointmentController;
        public DoctorController DoctorController;
        public BindingList<Appointment> appointments;
        public Doctor Doctor { get; set; }

        public RoomSchedule(User User)
        {
            InitializeComponent();
            SwitchLanguage();
            InitializeFields(User);
            cldSample.SelectedDate = DateTime.Now;
            InitializeAppointmentsList();
        }
        private void InitializeFields(User User)
        {
            var app = Application.Current as App;
            AppointmentController = app.AppointmentController;
            DoctorController = app.DoctorController;
            Doctor = DoctorController.ReadById(User.Id);
        }
            
        private void InitializeAppointmentsList()
        {
            List<Appointment> appointmentsList = AppointmentController.ReadByStartDate((DateTime)cldSample.SelectedDate);
            appointments = new BindingList<Appointment>(appointmentsList);
            RoomAppointmentGrid.ItemsSource = appointments;
        }

        private void cldSample_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeAppointmentsList();
            RoomAppointmentGrid.ItemsSource = appointments;
        }
        public void SwitchLanguage()
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            var app = App.Current as App;
            switch (app.LanguageCode)
            {
                case "en":
                    if (app.ThemeCode == "light")
                    {
                        dictionary.Source = new Uri("..\\StringResources.en.xaml", UriKind.Relative);

                    }
                    else
                    {
                        dictionary.Source = new Uri("..\\StringResources.en.dark.xaml", UriKind.Relative);
                    }
                    break;
                case "sr":
                    if (app.ThemeCode == "light")
                    {
                        dictionary.Source = new Uri("..\\StringResources.sr.xaml", UriKind.Relative);
                    }
                    else
                    {
                        dictionary.Source = new Uri("..\\StringResources.sr.dark.xaml", UriKind.Relative);
                    }
                    break;
                default:
                    dictionary.Source = new Uri("..\\StringResources.en.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
