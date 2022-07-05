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
    /// Interaction logic for AppointmentCreateDoctor.xaml
    /// </summary>
    public partial class AppointmentCreateDoctor : Window, INotifyPropertyChanged
    {
        private AppointmentController appointmentController;
        private PatientController patientController;
        private RoomController roomController;
        private DoctorController doctorController;
        private SpecialistController specialistController;
        private LoggedInController loggedInController;

        private readonly Doctor doctor;
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
        public AppointmentCreateDoctor(Doctor doctor)
        {
            InitializeComponent();
            datePickerStart.DisplayDateStart = DateTime.Now;
            this.DataContext = this; //nz sta znaci ali stoji u primeru za validaciju sa hci
            var app = Application.Current as App;
            appointmentController = app.AppointmentController;
            patientController = app.PatientController;
            roomController = app.RoomController;
            specialistController = app.SpecialistController;
            loggedInController = app.LoggedInController;
            this.doctor = doctor;
            InteractionKindComboBoxInitialization();
            InitializeLists();
            PatientGrid.ItemsSource = patients;
            RoomGrid.ItemsSource = rooms;
        }

        private void InitializeLists()
        {
            var allPatients = patientController.ReadAll();
            patients = new BindingList<Patient>(allPatients);

            var allRooms = roomController.ReadAll();
            rooms = new BindingList<Room>(allRooms);

        }
        private void InteractionKindComboBoxInitialization()
        {

            if (doctor.isSpecialist)
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

            DataContext = this;
            appointmentTypeComboBox.SelectedIndex = 0;
        }

        private AppointmentType ConvertStringToAppointmentType(string appointmentType)
        {
            if (appointmentType == "Operation")
            {
                return AppointmentType.Operation;
            }
            if (appointmentType == "CheckUp")
            {
                return AppointmentType.CheckUp;
            }
            return AppointmentType.Control;
        }
        public static DateTime MakeTime(DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
        private void saveAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Patient SelectedPatient = (Patient)PatientGrid.SelectedItem;
            Room SelectedRoom = (Room)RoomGrid.SelectedItem;

            if (SelectedPatient != null && SelectedRoom != null)
            {
                if(int.TryParse(Hour, out int hour) && int.TryParse(Minute, out int minute)
                    && int.TryParse(LenMinute, out int lenMinute))
                {
                    if(hour > 23 || hour < 0)
                    {
                        MessageBox.Show("Hour must be between 0 and 24");
                    }
                    else if(minute > 59 || minute < 0 ||lenMinute > 59 || lenMinute < 0)
                    {
                        MessageBox.Show("Minute must be between 0 and 60");
                    }
                    else
                    {
                        int appoinmentStartHourTime = hour;
                        int appoinmentStartMinuteTime = minute;
                        int appoinmentLenghtMinute = lenMinute;
                        TimeSpan appointmentLenght = new TimeSpan(appoinmentLenghtMinute / 60, appoinmentLenghtMinute % 60, 0);
                        DateTime appointmentStart = MakeTime((DateTime)datePickerStart.SelectedDate, appoinmentStartHourTime, appoinmentStartMinuteTime, 0, 0);
                        DateTime appointmentEnd = appointmentStart.Add(appointmentLenght);
                        AppointmentType appointmentType = ConvertStringToAppointmentType(appointmentTypeComboBox.SelectedItem.ToString());
                        if (!appointmentController.IsRoomFree(SelectedRoom.Id, appointmentStart, appointmentEnd))
                        {
                            MessageBox.Show("Room is taken at given time!");
                        }
                        else if (!appointmentController.IsPatientFree(SelectedPatient.Id, appointmentStart, appointmentEnd))
                        {
                            MessageBox.Show("Patient is busy at given time!");
                        }
                        else if (!appointmentController.IsDoctorFree(doctor.Id, appointmentStart, appointmentEnd))
                        {
                            MessageBox.Show("Doctor is busy at given time!");
                        }
                        else if (SelectedRoom.RoomType != appointmentType.ToString())
                        {
                            MessageBox.Show("Wrong room type for selected appointment type!");
                        }
                        else
                        {

                            CreateAppointmentDTO appointment = new CreateAppointmentDTO();
                            appointment.StartTime = MakeTime((DateTime)datePickerStart.SelectedDate, int.Parse(Hour), int.Parse(Minute), 0, 0);
                            appointment.EndTime = appointment.StartTime.Add(appointmentLenght);
                            appointment.Room = SelectedRoom;
                            appointment.Patient = SelectedPatient;
                            appointment.Purpose = appointmentType;
                            appointment.Doctor = doctor;

                            appointmentController.Create(appointment);
                            DoctorHomePage doctorHomePage = new DoctorHomePage(doctor);
                            doctorHomePage.Show();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            loggedInController.Delete(doctor.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void PatientGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
