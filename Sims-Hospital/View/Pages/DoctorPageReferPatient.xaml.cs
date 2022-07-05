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
    /// Interaction logic for DoctorPageReferPatient.xaml
    /// </summary>
    public partial class DoctorPageReferPatient : Page, INotifyPropertyChanged
    {
        private AppointmentController AppointmentController;
        private DoctorController DoctorController;
        private SpecialistController SpecialistController;
        private RoomController RoomController;
        private readonly Doctor Doctor;

        private Doctor SelectedDoctor;
        private Room SelectedRoom;
        private Patient SelectedPatient;
        private Appointment SelectedAppointment;
        private DateTime appointmentStart;
        private DateTime appointmentEnd;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
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

        public List<string> AppointmentTypeCollection { get; set; }
        public BindingList<Appointment> appointments;
        public BindingList<Room> rooms;
        public BindingList<Doctor> doctors;
        private static DoctorPageReferPatient instance = null;
        public static DoctorPageReferPatient Instance(Doctor Doctor, string languageCode)
        {
            if (instance == null)
            {
                instance = new DoctorPageReferPatient(Doctor, languageCode);
            }
            return instance;
        }
        public DoctorPageReferPatient(Doctor Doctor, string languageCode)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Doctor = Doctor;
            InitializeControllers();
            SwitchLanguage(languageCode);
            InitializeComboBox();
            InitializeLists();
        }
        private void InitializeControllers()
        {
            var app = Application.Current as App;
            AppointmentController = app.AppointmentController;
            DoctorController = app.DoctorController;
            RoomController = app.RoomController;
            SpecialistController = app.SpecialistController;
        }

        private void InitializeComboBox()
        {
            var app = Application.Current as App;
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

        private void InitializeLists()
        {
            InitializeAppointments();
            InitializeRooms();
            InitializeDoctors();
        }
        private void InitializeAppointments()
        {
            List<Appointment> doctorAppointments = AppointmentController.ReadByDoctorId(Doctor.Id);
            appointments = new BindingList<Appointment>(doctorAppointments);
            AppointmentGrid.ItemsSource = appointments;
        }
        private void InitializeRooms()
        {
            List<Room> allRooms = RoomController.ReadAll();
            rooms = new BindingList<Room>(allRooms);
            RoomGrid.ItemsSource = rooms;

        }

        private void InitializeDoctors()
        {
            List<Doctor> allDoctors = DoctorController.ReadAll();
            doctors = new BindingList<Doctor>(allDoctors);
            DoctorGrid.ItemsSource = doctors;
        }

        private bool GridsSelected()
        {
            return SelectedAppointment != null &&
                SelectedRoom != null
                && SelectedDoctor != null;
        }
        private void LoadSelectedFields()
        {
            SelectedAppointment = (Appointment)AppointmentGrid.SelectedItem;
            SelectedRoom = (Room)RoomGrid.SelectedItem;
            SelectedDoctor = (Doctor)DoctorGrid.SelectedItem;
        }
        private bool FieldsAreValid(int hour, int minute,
            int lenMinute, AppointmentType appointmentType)
        {
            var app = App.Current as App;
            if (hour > 23 || hour < 0)
            {
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("Hour must be between 0 and 24");
                }
                else
                {
                    MessageBox.Show("Sat mora biti izmedju 0 i 24");
                }

                return false;
            }
            else if (minute > 59 || minute < 0 || lenMinute > 59 || lenMinute < 0)
            {
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("Minute must be between 0 and 60");
                }
                else
                {
                    MessageBox.Show("Minut mora biti izmedju 0 i 60");
                }
                return false;
            }
            else if (DateTime.Compare(SelectedAppointment.StartTime, DateTime.Now) > 0)
            {
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("Patient can't be refered before the start of appointment!");
                }
                else
                {
                    MessageBox.Show("Ne moze da se uputi pacijent pre pocetka termina!");
                }
                return false;
            }
            else if (SelectedRoom.RoomType != appointmentType.ToString())
            {
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("Room type doesn't match appointment type!");
                }
                else
                {
                    MessageBox.Show("Tip sobe se ne slaze sa tipom termina!");
                }
                return false;
            }
            else if (SelectedRoom.RoomType.Equals("Operation") && !SelectedDoctor.isSpecialist)
            {
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("A generel practicioner cannot do an operation!");
                }
                else
                {
                    MessageBox.Show("Lekaru opste prakse ne moze da se zakaze operacija!");
                }
                return false;
            }
            return true;
        }

        private void CalculateAppointmentStart(int hour, int minute)
        {
            appointmentStart = DateUtils.CreateTime((DateTime)datePickerStart.SelectedDate, hour, minute);
        }
        private void CalculateAppointmentEnd(int lenMinute)
        {
            TimeSpan appointmentLenght = new TimeSpan(lenMinute / 60, lenMinute % 60, 0);
            appointmentEnd = appointmentStart.Add(appointmentLenght);
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            LoadSelectedFields();
            if (GridsSelected())
            {
                SelectedPatient = SelectedAppointment.Patient;
                AppointmentType appointmentType = AppointmentUtils.ConvertStringToAppointmentType(appointmentTypeComboBox.SelectedItem.ToString());
                //Parse hours and minutes only if they can be parsed
                if (int.TryParse(Hour, out int hour) && int.TryParse(Minute, out int minute)
                    && int.TryParse(LenMinute, out int lenMinute))
                {
                    if (FieldsAreValid(hour, minute, lenMinute, appointmentType))
                    {
                        CalculateAppointmentStart(hour, minute);
                        CalculateAppointmentEnd(lenMinute);
                        if ((bool)!EmergencyCheckBox.IsChecked)
                        {
                            if (SheduleChecksPassed(appointmentStart, appointmentEnd))
                            {
                                CreateAppointment(lenMinute, appointmentType);
                                ClearFields();
                            }

                        }
                        else
                        {
                            CreateAppointment(lenMinute, appointmentType);
                            ClearFields();
                        }
                    }
                }
            }
            else
            {
                var app = App.Current as App;
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("Appointment, doctor and patient must be selected!");
                }
                else
                {
                    MessageBox.Show("Termin, doktor i pacijent moraju biti izabrani!");
                }
            }
        }

        private bool SheduleChecksPassed(DateTime appointmentStart, DateTime appointmentEnd)
        {
            var app = App.Current as App;
            if (!AppointmentController.IsRoomFree(SelectedRoom.Id, appointmentStart, appointmentEnd))
            {
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("Room is taken at given time!");
                }
                else
                {
                    MessageBox.Show("Soba je okupirana u izabranom vremenu!");
                }
                return false;
            }
            else if (!AppointmentController.IsPatientFree(SelectedPatient.Id, appointmentStart, appointmentEnd))
            {
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
            else if (!AppointmentController.IsDoctorFree(SelectedDoctor.Id, appointmentStart, appointmentEnd))
            {
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
            return true;
        }

        private void CreateAppointment(int lenMinute, AppointmentType appointmentType)
        {
            CreateAppointmentDTO Appointment = new CreateAppointmentDTO();
            Appointment.StartTime = DateUtils.CreateTime((DateTime)datePickerStart.SelectedDate, int.Parse(Hour), int.Parse(Minute), 0, 0);
            TimeSpan appointmentLenght = new TimeSpan(lenMinute / 60, lenMinute % 60, 0);
            Appointment.EndTime = Appointment.StartTime.Add(appointmentLenght);
            Appointment.Room = SelectedRoom;
            Appointment.Patient = SelectedPatient;
            Appointment.Purpose = appointmentType;
            Appointment.Doctor = SelectedDoctor;
            AppointmentController.Create(Appointment);
            var app = App.Current as App;
            if (app.LanguageCode == "en")
            {
                MessageBox.Show("Patient refered successfully!");
            }
            else
            {
                MessageBox.Show("Uspesno upucen pacijent!");
            }
        }
        private void ClearFields()
        {
            datePickerStart.Text = "";
            appointmentStartHour.Text = "";
            appointmentStartMinute.Text = "";
            appointmentLenghtMinute.Text = "";
            EmergencyCheckBox.IsChecked = false;

        }

        private void SearchDoctors_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tbx = sender as TextBox;
            if (tbx.Text != "")
            {
                var filteredList = doctors.Where(x => x.NameLastName.ToLower().Contains(tbx.Text.ToLower()));
                DoctorGrid.ItemsSource = null;
                DoctorGrid.ItemsSource = filteredList;
            }
            else
            {
                DoctorGrid.ItemsSource = doctors;
            }
        }

        private void SearchRooms_TextChanged(object sender, TextChangedEventArgs e)
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

        private void SearchAppointments_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tbx = sender as TextBox;
            if (tbx.Text != "")
            {
                var filteredList = appointments.Where(x => x.Patient.NameLastName.ToLower().Contains(tbx.Text.ToLower()));
                AppointmentGrid.ItemsSource = null;
                AppointmentGrid.ItemsSource = filteredList;
            }
            else
            {
                AppointmentGrid.ItemsSource = appointments;
            }
        }

        private void DoctorGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Doctor SelectedDoctor = (Doctor)DoctorGrid.SelectedItem;
            //must check if is null because typing in searchbox
            //can change SelectedDoctor to be null!
            if (SelectedDoctor != null)
            {
                if (SelectedDoctor.isSpecialist)
                {
                    specialisationTextbox.Text = SpecialistController.ReadById(SelectedDoctor.Id).Specialization;
                }
                else
                {
                    specialisationTextbox.Text = "Opsta praksa";
                }
            }
            else
            {
                specialisationTextbox.Text = "";
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
