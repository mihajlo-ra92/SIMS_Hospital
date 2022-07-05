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
using Controller;
using Dto;
using Model;
using Sims_Hospital.Utils;

namespace Sims_Hospital.View
{
    public partial class AppointmentEditDoctor : Window
    {
        public List<string> AppointmentTypeCollection { get; set; }
        public Appointment Appointment { get; set; }
        public Doctor Doctor;
        private LoggedInController LoggedInController;
        private AppointmentController AppointmentController;
        private RoomController RoomController;
        private PatientController PatientController;
        private DoctorController DoctorController;

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
        public BindingList<Patient> patients;
        public BindingList<Room> rooms;
        public AppointmentEditDoctor(Appointment appointment, Doctor doctor, string languageCode)
        {
            InitializeComponent();
            InitializeFields(appointment, doctor);
            SwitchLanguage(languageCode);
            InteractionKindComboBoxInitialization();
            InitializeLists();
            InitializeGrids();
            InitializeParams();

        }
        private void InitializeGrids()
        {
            PatientGrid.ItemsSource = patients;
            RoomGrid.ItemsSource = rooms;
        }
        private void InitializeFields(Appointment appointment, Doctor doctor)
        {
            this.Doctor = doctor;
            Appointment = appointment;
            var app = Application.Current as App;
            this.AppointmentController = app.AppointmentController;
            this.RoomController = app.RoomController;
            this.PatientController = app.PatientController;
            this.LoggedInController = app.LoggedInController;
            this.DoctorController = app.DoctorController;
        }
        private void InitializeParams()
        {
            datePickerStart.Text = Appointment.StartTime.ToString();
            Hour = Appointment.StartTime.Hour.ToString();
            Minute = Appointment.StartTime.Minute.ToString();
            DateTime startTime = DateUtils.CreateTime(Appointment.StartTime, Appointment.StartTime.Hour, Appointment.StartTime.Minute);
            DateTime endTime = DateUtils.CreateTime(Appointment.EndTime, Appointment.EndTime.Hour, Appointment.EndTime.Minute);
            //TimeSpan AppoinmentLen = Appointment.EndTime - Appointment.StartTime;
            TimeSpan AppoinmentLen = endTime - startTime;
            LenMinute = AppoinmentLen.TotalMinutes.ToString();
            appointmentTypeComboBox.SelectedIndex = AppointmentUtils.ConvertAppointmentTypeToIndex(Appointment.Purpose);
            PatientGrid.SelectedItem = Appointment.Patient;
            RoomGrid.SelectedItem = Appointment.Room;
        }

        private void InitializeLists()
        {
            var allPatients = PatientController.ReadAll();
            patients = new BindingList<Patient>(allPatients);

            var allRooms = RoomController.ReadAll();
            rooms = new BindingList<Room>(allRooms);

        }

        private void InteractionKindComboBoxInitialization()
        {
            var app = App.Current as App;
            if (app.LanguageCode == "en")
            {
                if (Doctor.isSpecialist)
                {
                    AppointmentTypeCollection = new List<string>()
                {
                    "Operation",
                    "CheckUp"
                };
                }
                else
                {
                    AppointmentTypeCollection = new List<string>()
                {
                    "CheckUp"
                };
                }
            }
            else
            {
                if (Doctor.isSpecialist)
                {
                    AppointmentTypeCollection = new List<string>()
                {
                    "Operacija",
                    "Pregled"
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
                if (int.TryParse(Hour, out int hour) && int.TryParse(Minute, out int minute)
                    && int.TryParse(LenMinute, out int lenMinute))
                {
                    if (hour > 23 || hour < 0)
                    {
                        MessageBox.Show("Sat mora biti izmedju 0 i 24");
                    }
                    else if (minute > 59 || minute < 0 || lenMinute > 59 || lenMinute < 0)
                    {
                        MessageBox.Show("Minut mora biti izmedju 0 i 60");
                    }
                    else
                    {
                        EditAppointmentDTO appointment = new EditAppointmentDTO();
                        int appoinmentStartHourTime = hour;
                        int appoinmentStartMinuteTime = minute;
                        int appoinmentLenghtMinute = lenMinute;
                        TimeSpan appointmentLenght = new TimeSpan(appoinmentLenghtMinute / 60, appoinmentLenghtMinute % 60, 0);
                        DateTime appointmentStart = DateUtils.CreateTime((DateTime)datePickerStart.SelectedDate, appoinmentStartHourTime, appoinmentStartMinuteTime, 0, 0);
                        DateTime appointmentEnd = appointmentStart.Add(appointmentLenght);
                        AppointmentType appointmentType = AppointmentUtils.ConvertStringToAppointmentType(appointmentTypeComboBox.SelectedItem.ToString());
                        if (!AppointmentController.IsRoomFree(SelectedRoom.Id, appointmentStart, appointmentEnd, Appointment.Id))
                        {
                            MessageBox.Show("Room is taken at given time!");
                        }
                        else if (!AppointmentController.IsPatientFree(SelectedPatient.Id, appointmentStart, appointmentEnd, Appointment.Id))
                        {
                            MessageBox.Show("Patient is busy at given time!");
                        }
                        else if (!AppointmentController.IsDoctorFree(this.Doctor.Id, appointmentStart, appointmentEnd, Appointment.Id))
                        {
                            MessageBox.Show("Doctor is busy at given time!");
                        }
                        else if (SelectedRoom.RoomType != appointmentType.ToString())
                        {
                            MessageBox.Show("Wrong room type for selected appointment type!");
                        }
                        else
                        {
                            appointment.Id = Appointment.Id;
                            appointment.StartTime = DateUtils.CreateTime((DateTime)datePickerStart.SelectedDate, appoinmentStartHourTime, appoinmentStartMinuteTime, 0, 0);
                            appointment.EndTime = appointment.StartTime.Add(appointmentLenght);
                            appointment.Doctor = Doctor;
                            appointment.Room = SelectedRoom;
                            appointment.Purpose = appointmentType;
                            appointment.Patient = SelectedPatient;
                            AppointmentController.Edit(appointment);
                            DoctorHomePage doctorHomePage = new DoctorHomePage(Doctor);
                            doctorHomePage.Show();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            LoggedInController.Delete(Doctor.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
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
        private void SwitchLanguage(string languageCode)
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

        private void RoomScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            RoomSchedule roomSchedule = new RoomSchedule(Doctor);
            roomSchedule.Show();
        }
    }
}
