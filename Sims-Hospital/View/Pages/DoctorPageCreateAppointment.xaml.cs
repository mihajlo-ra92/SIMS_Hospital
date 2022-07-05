using Controller;
using Dto;
using Model;
using Sims_Hospital.Utils;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for DoctorPageCreateAppointment.xaml
    /// </summary>
    public partial class DoctorPageCreateAppointment : Page, INotifyPropertyChanged
    {
        private AppointmentController AppointmentController;
        private PatientController PatientController;
        private RoomController RoomController;
        private SpecialistController SpecialistController;
        private LoggedInController LoggedInController;
        private static DoctorPageCreateAppointment instance = null;
        public static DoctorPageCreateAppointment Instance(Doctor Doctor, string languageCode)
        {
            if (instance == null)
            {
                instance = new DoctorPageCreateAppointment(Doctor, languageCode);
            }
            return instance;
        }

        private Doctor Doctor;
        private DateTime AppointmentStart;
        private DateTime AppointmentEnd;
        private Room Room;
        private Patient Patient;
        private AppointmentType AppointmentType;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _patientUsername;
        private string _roomName;
        private string _hour;
        private string _minute;
        private string _lenMinute;
        public string Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                if (value != _hour)
                {
                    _hour = value;
                    OnPropertyChanged("Hour");
                }
            }
        }
        public string Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                if (value != _minute)
                {
                    _minute = value;
                    OnPropertyChanged("Minute");
                }
            }
        }
        public string LenMinute
        {
            get
            {
                return _lenMinute;
            }
            set
            {
                if (value != _lenMinute)
                {
                    _lenMinute = value;
                    OnPropertyChanged("LenMinute");
                }
            }
        }
        public string PatientUsername
        {
            get
            {
                return _patientUsername;
            }
            set
            {
                if (value != _patientUsername)
                {
                    _patientUsername = value;
                    OnPropertyChanged("PatientUsername");
                }
            }
        }
        public string RoomName
        {
            get
            {
                return _roomName;
            }
            set
            {
                if (value != _roomName)
                {
                    _roomName = value;
                    OnPropertyChanged("RoomName");
                }
            }
        }

        public List<string> AppointmentTypeCollection { get; set; }
        public BindingList<Patient> patients;
        public BindingList<Room> rooms;
        public DoctorPageCreateAppointment(Doctor Doctor, string languageCode)
        {
            InitializeComponent();
            InitializeFields(Doctor);
            SwitchLanguage(languageCode);
            this.DataContext = this;
            InteractionKindComboBoxInitialization();
            InitializeLists();
        }
        private void InitializeFields(Doctor Doctor)
        {
            var app = Application.Current as App;
            AppointmentController = app.AppointmentController;
            PatientController = app.PatientController;
            RoomController = app.RoomController;
            SpecialistController = app.SpecialistController;
            LoggedInController = app.LoggedInController;
            this.Doctor = Doctor;
        }
        private void InitializeLists()
        {
            var allPatients = PatientController.ReadAll();
            patients = new BindingList<Patient>(allPatients);
            var allRooms = RoomController.ReadAll();
            rooms = new BindingList<Room>(allRooms);
            PatientGrid.ItemsSource = patients;
            RoomGrid.ItemsSource = rooms;

        }
        private void InteractionKindComboBoxInitialization()
        {

            var app = Application.Current as App;
            if (Doctor.isSpecialist)
            {
                if (app.LanguageCode == "en")
                {
                    AppointmentTypeCollection = new List<string>()
                    {
                        "Operation",
                        "Checkup"
                    };
                }
                else
                {
                    AppointmentTypeCollection = new List<string>()
                    {
                        "Operacija",
                        "Pregled"
                    };
                }
            }
            else
            {
                if (app.LanguageCode == "en")
                {
                    AppointmentTypeCollection = new List<string>()
                    {
                        "Checkup"
                    };
                }
                else
                {
                    AppointmentTypeCollection = new List<string>()
                    {
                        "Pregled"
                    };
                }

            }

            DataContext = this;
            appointmentTypeComboBox.SelectedIndex = 0;
        }
        private void saveAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Patient SelectedPatient = (Patient)PatientGrid.SelectedItem;
            Room SelectedRoom = (Room)RoomGrid.SelectedItem;

            if (SelectedPatient != null && SelectedRoom != null)
            {

                if (int.TryParse(Hour, out int startHour) && int.TryParse(Minute, out int startMinute)
                    && int.TryParse(LenMinute, out int lenMinute))
                {
                    if (TimeIsValid(startHour, startMinute, lenMinute))
                    {
                        LoadParametars(SelectedRoom, SelectedPatient, startHour, startMinute, lenMinute);
                        if (AppointmentCanBeBooked())
                        {
                            CreateAppointment();
                            var app = App.Current as App;
                            if (app.LanguageCode == "en")
                            {
                                MessageBox.Show("Appointment created succesfully!");
                            }
                            else
                            {
                                MessageBox.Show("Termin uspešno zakazan!");
                            }
                            ClearFields();
                        }
                    }
                }
            }
        }
        private bool TimeIsValid(int startHour, int startMinute, int lenMinute)
        {
            if (startHour > 23 || startHour < 0)
            {
                var app = App.Current as App;
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("Hour must be between 0 and 24");
                }
                else
                {
                    MessageBox.Show("Sat mora biti između 0 i 24");
                }
                return false;
            }
            if (startMinute > 59 || startMinute < 0 || lenMinute > 59 || lenMinute < 0)
            {
                var app = App.Current as App;
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("Minute must be between 0 and 60");
                }
                else
                {
                    MessageBox.Show("Minut mora da bude između 0 i 60");
                }
                return false;
            }
            return true;
        }
        private bool AppointmentCanBeBooked()
        {
            if (Room.RoomType != AppointmentType.ToString())
            {
                var app = App.Current as App;
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("Wrong room type for selected appointment type!");
                }
                else
                {
                    MessageBox.Show("Pogrešan tip sobe za izabranu vrstu termina!");
                }
                return false;
            }
            if (!(bool)EmergencyCheckBox.IsChecked)
            {
                if (!AppointmentController.IsRoomFree(Room.Id, AppointmentStart, AppointmentEnd))
                {
                    var app = App.Current as App;
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("Room is taken at given time!");
                    }
                    else
                    {
                        MessageBox.Show("Soba je zauzeta u izabranom vremenu!");
                    }
                    return false;
                }
                else if (!AppointmentController.IsPatientFree(Patient.Id, AppointmentStart, AppointmentEnd))
                {
                    var app = App.Current as App;
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("Patient is busy at given time!");
                    }
                    else
                    {
                        MessageBox.Show("Pacijent je zauzet u izabranom vremenu!");
                    }
                    return false;
                }
                else if (!AppointmentController.IsDoctorFree(Doctor.Id, AppointmentStart, AppointmentEnd))
                {
                    var app = App.Current as App;
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("Doctor is busy at given time!");
                    }
                    else
                    {
                        MessageBox.Show("Doktor je zauzet u izabranom vremenu!");
                    }
                    return false;
                }
            }
            return true;
        }
        private void LoadParametars(Room SelectedRoom, Patient SelectedPatient,
            int startHour, int startMinute, int lenMinute)
        {
            this.Room = SelectedRoom;
            this.Patient = SelectedPatient;
            this.AppointmentStart = DateUtils.CreateTime((DateTime)datePickerStart.SelectedDate, startHour, startMinute);
            this.AppointmentEnd = DateUtils.CreateEndTime(AppointmentStart, lenMinute);
            this.AppointmentType = AppointmentUtils.ConvertStringToAppointmentType(appointmentTypeComboBox.SelectedItem.ToString());
        }
        private void CreateAppointment()
        {
            CreateAppointmentDTO Appointment = new CreateAppointmentDTO();
            Appointment.StartTime = AppointmentStart;
            Appointment.EndTime = AppointmentEnd;
            Appointment.Room = Room;
            Appointment.Patient = Patient;
            Appointment.Purpose = AppointmentType;
            Appointment.Doctor = Doctor;
            AppointmentController.Create(Appointment);
        }
        private void ClearFields()
        {
            datePickerStart.Text = "";
            appointmentStartHour.Text = "";
            appointmentStartMinute.Text = "";
            appointmentLenghtMinute.Text = "";
        }
        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            LoggedInController.Delete(Doctor.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Patients_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tbx = sender as TextBox;
            if (tbx.Text != "")
            {
                var filteredList = patients.Where(x => x.NameLastName.ToLower().Contains(tbx.Text.ToLower()));
                PatientGrid.ItemsSource = null;
                PatientGrid.ItemsSource = filteredList;
            }
            else
            {
                PatientGrid.ItemsSource = patients;
            }
        }
        private void Rooms_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tbx = sender as TextBox;
            if (tbx.Text != "")
            {
                var filteredList = rooms.Where(x => x.RoomName.ToLower().Contains(tbx.Text.ToLower()));
                RoomGrid.ItemsSource = null;
                RoomGrid.ItemsSource = filteredList;
            }
            else
            {
                RoomGrid.ItemsSource = rooms;
            }
        }

        private void RoomScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            RoomSchedule roomSchedule = new RoomSchedule(Doctor);
            roomSchedule.Show();
        }
        public void SwitchLanguage(string languageCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            var app = App.Current as App;
            switch (languageCode)
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
        public void SwitchTheme(string themeCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            var app = App.Current as App;
            switch (themeCode)
            {
                case "light":
                    if (app.LanguageCode == "en")
                    {
                        dictionary.Source = new Uri("..\\StringResources.en.xaml", UriKind.Relative);

                    }
                    else
                    {
                        dictionary.Source = new Uri("..\\StringResources.sr.xaml", UriKind.Relative);
                    }
                    break;
                case "dark":
                    if (app.LanguageCode == "en")
                    {
                        dictionary.Source = new Uri("..\\StringResources.en.dark.xaml", UriKind.Relative);
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
