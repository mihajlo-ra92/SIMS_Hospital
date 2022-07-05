using Controller;
using Dto;
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
    public partial class AppointmentEditPatient : Window
    {
        private RoomController RoomController;
        private DoctorController DoctorController;
        private SpecialistController SpecialistController;
        public MaliciouslyPatientController MaliciouslyPatientController;
        public List<string> PriorityCollection { get; set; }
        public List<Doctor> GeneralPracticionalDoctors { get; set; }
        public List<Specialist> SpecialistDoctors { get; set; }
        public Patient Patient;
        private readonly bool IsSecretary;
        private LoggedInController loggedInController;
        private bool doctorFree ;
        public Appointment Appointment { get; set; }
        private UserNotificationController userNotificationController { get; set; }
        private AppointmentController AppointmentController { get; set; }

        public AppointmentEditPatient(Appointment appointment,
                                      Patient patient, bool IsSecretary)
        {
            InitializeComponent();
            var app = Application.Current as App;
            RoomController = app.RoomController;
            DoctorController = app.DoctorController;
            MaliciouslyPatientController = app.MaliciouslyPatientController;
            loggedInController = app.LoggedInController;
            userNotificationController = app.UserNotificationController;
            SpecialistController = app.SpecialistController;
            AppointmentController = app.AppointmentController;

            Patient = patient;
            this.IsSecretary = IsSecretary;
            Appointment = appointment;
            GeneralPracticionalDoctors = DoctorController.ReadAllNotSpecialist();
            SpecialistDoctors = SpecialistController.ReadAll();

            InitializeFields();

        }

        private void InitializeFields()
        {
            datePicker.Text = Appointment.StartTime.ToString();
            datePicker.DisplayDateStart = Appointment.StartTime.AddDays(-4);
            datePicker.DisplayDateEnd = Appointment.StartTime.AddDays(4);
            timeTextHour.Text = Appointment.StartTime.Hour.ToString();
            timeTextMinutes.Text = Appointment.StartTime.Minute.ToString();
            PriortyComboBoxInitialization();

            if (IsSecretary == true && Appointment.Purpose == AppointmentType.Operation)
            {
                Specialist specialist = SpecialistController.ReadById(Appointment.Doctor.Id);

                List<Doctor> specialistWithSameSpecializations = new List<Doctor>();
                foreach (var s in SpecialistDoctors)
                {
                    if (s.Specialization == specialist.Specialization)
                    {
                        specialistWithSameSpecializations.Add(DoctorController.ReadById(s.Id));
                    }
                }
                doctorComboBox.ItemsSource = specialistWithSameSpecializations;
                doctorComboBox.SelectedValue = specialistWithSameSpecializations.Where(x => x.Id == Appointment.Doctor.Id).First();
            }
            else if (IsSecretary == true)
            {
                doctorComboBox.ItemsSource = DoctorController.ReadAll();
                doctorComboBox.SelectedValue = DoctorController.ReadAll().Where(x => x.Id == Appointment.Doctor.Id).First();
            }
            else
            {
                doctorComboBox.ItemsSource = GeneralPracticionalDoctors;
                doctorComboBox.SelectedValue = ConvertDoctorToString(Appointment.Doctor.Id);
            }
            doctorComboBox.DisplayMemberPath = "NameLastName";


        }

        private Doctor ConvertDoctorToString(int doctorId)
        {
            return GeneralPracticionalDoctors.Where(x => x.Id == doctorId).First();
        }

        private bool IsDoctorFree(DateTime newAppointmentTime,Doctor doctor,List<Appointment> appointmentList) 
        {
            bool DoctorFree = true;
            foreach (Appointment appointment in appointmentList)
            {
                if (DateTime.Compare(appointment.StartTime.AddMinutes(-20), newAppointmentTime) > 0 && DateTime.Compare(appointment.EndTime, newAppointmentTime) < 0)
                {
                    DoctorFree = false;
                }
            }
            return doctorFree;
        }

        private bool IsAvaliableMoveAppointment(DateTime newAppointmentTime) 
        {
            int dayAfer = DateTime.Compare(Appointment.StartTime.AddDays(4), newAppointmentTime);// treba biti > 0
            int dayBefore = DateTime.Compare(newAppointmentTime, Appointment.StartTime.AddDays(-4));// treba biti > 0

            if(dayAfer > 0 && dayBefore > 0)
            {
                return true;
            }
            else
            {
               return false;
            }
        }



        public void SaveAppointmentEditButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime newAppointmentTime = MakeTime((DateTime)datePicker.SelectedDate, Int32.Parse(timeTextHour.Text), Int32.Parse((timeTextMinutes.Text)));
            Doctor doctor = (Doctor)doctorComboBox.SelectedItem;
            List<Appointment> appointments = AppointmentController.ReadByDoctorId(doctor.Id);
            doctorFree = IsDoctorFree(newAppointmentTime, doctor, appointments);

            bool availableMove = IsAvaliableMoveAppointment(Appointment.StartTime);

            if(doctorFree = false)
            {
                MessageBox.Show("Odabrani doktor nije slobodan u biranom terminu");
            }
            else if (availableMove == false)
            {
                MessageBox.Show("Nije moguce pomeriti termin za 4 dana pre ili posle inicijalnog termina");
                datePicker.Text = Appointment.StartTime.ToString();
            }//beice validacija pa nece ni biti potreban ovaj
            else if (Int32.Parse(timeTextHour.Text) > 21 || Int32.Parse(timeTextHour.Text) < 8 || Int32.Parse(timeTextMinutes.Text) >59 || Int32.Parse(timeTextMinutes.Text) < 0) 
            {
                MessageBox.Show("Vreme je pogresno uneseno.");
            }
            else
            {
                Doctor oldDoctor = Appointment.Doctor;
                DateTime oldDate = Appointment.StartTime;

                if (IsSecretary == true)
                {
                    EditAppointmentDTO editAppointmentDTO = new EditAppointmentDTO()
                    {
                        Id = Appointment.Id,
                        StartTime = MakeTime((DateTime)datePicker.SelectedDate, Int32.Parse(timeTextHour.Text), Int32.Parse((timeTextMinutes.Text))),
                        Doctor = (Doctor)doctorComboBox.SelectedItem,
                        Patient = Patient,
                        Room = RoomController.ReadById(Appointment.Room.Id),
                        Purpose = Appointment.Purpose,
                    };

                    EditAppointmentPatientDTO editAppointmentPatientDTO = new EditAppointmentPatientDTO()
                    {
                        Id = Appointment.Id,
                        StartTime = MakeTime((DateTime)datePicker.SelectedDate, Int32.Parse(timeTextHour.Text), Int32.Parse((timeTextMinutes.Text))),
                        Doctor = (Doctor)doctorComboBox.SelectedItem,
                        Patient = Patient,
                        //Room = RoomController.ReadById(Appointment.Room.Id),
                    };

                    CreateNotificationDTO createNotificationPatientDTO = new CreateNotificationDTO()
                    {
                        Description = GetAppointmentDescription(oldDoctor, oldDate),
                        User = Patient
                    };


                    CreateNotificationDTO createNotificationDoctorDTO = new CreateNotificationDTO()
                    {
                        Description = GetAppointmentDescription(oldDoctor, oldDate),
                        User = doctor
                    };

                    AppointmentController.Edit(editAppointmentDTO);
                    AppointmentController.EditByPatient(editAppointmentPatientDTO);
                    userNotificationController.Create(createNotificationPatientDTO);
                    userNotificationController.Create(createNotificationDoctorDTO);

                    if (doctor != Appointment.Doctor)
                    {
                        CreateNotificationDTO createNotificationNewDoctorDTO = new CreateNotificationDTO()
                        {
                            Description = GetAppointmentDescription(oldDoctor, oldDate),
                            User = Appointment.Doctor
                        };
                        userNotificationController.Create(createNotificationNewDoctorDTO);
                    }

                    PatientAppointments patientAppointments = new PatientAppointments(Patient);
                    patientAppointments.Show();
                }else
                {
                    EditAppointmentPatientDTO editAppointmentPatientDTO = new EditAppointmentPatientDTO()
                    {
                        Id = Appointment.Id,
                        StartTime = MakeTime((DateTime)datePicker.SelectedDate, Int32.Parse(timeTextHour.Text), Int32.Parse((timeTextMinutes.Text))),
                        Doctor = (Doctor)doctorComboBox.SelectedItem,
                        Patient = Patient,
                        //Room = RoomController.ReadById(Appointment.Room.Id),
                    };
                    AppointmentController.EditByPatient(editAppointmentPatientDTO);
                    BackToPatientHomePage();
                }
                
            }
        }

        private void BackToPatientHomePage()
        {
            MaliciouslyPatient patient = new MaliciouslyPatient()
            {
                Patient = Appointment.Patient,
                EditTime= DateTime.Now
            };
            MaliciouslyPatientController.Create(patient);
            if (MaliciouslyPatientController.IsPatientMaliciously(Appointment.Patient.Id))
            {
                loggedInController.Delete(Appointment.Patient.Id);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                PatientHomePage patientHomePage = new PatientHomePage(Appointment.Patient);
                patientHomePage.Show();
                this.Close();
            }
        }


        private string GetAppointmentDescription(Doctor doctor, DateTime oldDate)
        {
            string output = "";

            output += "Pacijent: " + Appointment.Patient.NameLastName + "\n";
            output += "Termin zakazan za " + oldDate.ToString() + " je pomeren za " + Appointment.StartTime.ToString() + "\n";
            if (doctor != Appointment.Doctor)
            {
                output += "Novi lekar je: " + Appointment.Doctor.NameLastName + "\n";
            }
            return output;
        }

        private DateTime MakeTime(DateTime dateTime,int hours,int minutes)
        {
            return new DateTime(dateTime.Year,dateTime.Month,dateTime.Day,hours,minutes,0);
        }



        private void PriortyComboBoxInitialization()
        {

            PriorityCollection = new List<string>()
            {
                "Lekar",
                "Termin"
            };

            DataContext = this;
        }

        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            loggedInController.Delete(Patient.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
