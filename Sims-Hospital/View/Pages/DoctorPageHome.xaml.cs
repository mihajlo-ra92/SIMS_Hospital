using Controller;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using Model;
using Sims_Hospital.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for DoctorPageHome.xaml
    /// </summary>
    public partial class DoctorPageHome : Page
    {
        public AppointmentController AppointmentController;
        public DoctorController DoctorController;
        public MedicalRecordController MedicalRecordController;
        public GuestMedicalRecordController GuestMedicalRecordController;
        public ReportController ReportController;
        public PrescriptionController PrescriptionController;
        public BindingList<Appointment> appointments;
        private LoggedInController LoggedInController;
        private static DoctorPageHome instance = null;

        public DoctorPageHome(User User, string languageCode)
        {
            InitializeComponent();
            InitializeFields(User);
            SwitchLanguage(languageCode);
            cldSample.SelectedDate = DateTime.Now.AddDays(0); //stoji zbog hci, izbacice se
            FillCalendar();
            InitializeAppointmentsList();
        }
        public static DoctorPageHome Instance(User User, string languageCode)
        {
                if (instance == null)
                {
                    instance = new DoctorPageHome(User, languageCode);
                }
                return instance;
        }

        public Doctor Doctor { get; set; }

        

        private void FillCalendar()
        {
            //iterating trough all appointments, not just the ones that are being shown
            //by the datagrid
            foreach (Appointment appointment in AppointmentController.ReadByDoctorId(Doctor.Id))
            {
                //cldSample.BlackoutDates.Clear();
                //cldSample.BlackoutDates.AddDatesInPast();
                //var range = new CalendarDateRange(DateTime.Today, DateTime.Today.AddDays(10));
                //cldSample.BlackoutDates.Add(range);
                //cldSample.BlackoutDates.Remove(new CalendarDateRange(appointment.StartTime, appointment.StartTime));

                //cldSample.BlackoutDates.Add(new CalendarDateRange(appointment.StartTime, appointment.StartTime));

            }
        }
        private void InitializeFields(User User)
        {
            var app = Application.Current as App;
            AppointmentController = app.AppointmentController;
            DoctorController = app.DoctorController;
            MedicalRecordController = app.MedicalRecordController;
            GuestMedicalRecordController = app.GuestMedicalRecordController;
            ReportController = app.ReportController;
            PrescriptionController = app.PrescriptionController;
            Doctor = DoctorController.ReadById(User.Id);
            LoggedInController = app.LoggedInController;
        }
        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            AppointmentCreateDoctor appointmentCreate = new AppointmentCreateDoctor(Doctor);
            appointmentCreate.Show();
        }

        private void InitializeAppointmentsList()
        {
            List<Appointment> doctorAppointments = AppointmentController.
                ReadByDoctorIdAndStartDate(Doctor.Id, (DateTime)cldSample.SelectedDate);
            //List<Appointment> doctorAppointments = AppointmentController.ReadByDoctorId(Doctor.Id);
            appointments = new BindingList<Appointment>(doctorAppointments);
            CustomerGrid.ItemsSource = appointments;
        }

        private void EditAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment SelectedAppointment = (Appointment)CustomerGrid.SelectedItem;
            if (SelectedAppointment != null)
            {
                var app = App.Current as App;
                AppointmentEditDoctor appointmentEditDoctor = new AppointmentEditDoctor(SelectedAppointment, Doctor, app.LanguageCode);
                appointmentEditDoctor.Show();
            }
        }
        private void DeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment SelectedAppointment = (Appointment)CustomerGrid.SelectedItem;
            if (SelectedAppointment != null)
            {
                var app = App.Current as App;
                if (app.LanguageCode == "en")
                {
                    if (MessageBox.Show("Are you sure", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        AppointmentController.Delete(SelectedAppointment.Id);
                        InitializeComponent();
                        InitializeAppointmentsList();
                        CustomerGrid.ItemsSource = appointments;
                    }
                }
                else
                {
                    if (MessageBox.Show("Da li ste sigurni?", "Pažnja", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        AppointmentController.Delete(SelectedAppointment.Id);
                        InitializeComponent();
                        InitializeAppointmentsList();
                        CustomerGrid.ItemsSource = appointments;
                    }
                }

            }
        }

        private void LogoutUser_Click(object sender, RoutedEventArgs e)
        {
            LoggedInController.Delete(Doctor.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void showReport_Click(object sender, RoutedEventArgs e)
        {
            Appointment SelectedAppointment = (Appointment)CustomerGrid.SelectedItem;
            if (SelectedAppointment != null)
            {
                if (DateUtils.DateTimeStarted(SelectedAppointment.StartTime))
                {
                    var app = App.Current as App;
                    ReportWindow reportWindow = new ReportWindow(SelectedAppointment, app.LanguageCode);
                    reportWindow.Show();
                }
                else
                {
                    var app = App.Current as App;
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("Appointment has not started.");
                    }
                    else
                    {
                        MessageBox.Show("Termin jos nije poceo.");
                    }

                }
            }
        }
        private void writePrescription_Click(object sender, RoutedEventArgs e)
        {
            Appointment SelectedAppointment = (Appointment)CustomerGrid.SelectedItem;
            if (SelectedAppointment != null)
            {
                var app = App.Current as App;
                if (DateUtils.DateTimeStarted(SelectedAppointment.StartTime))
                {
                    WritePrescription prescriptionWindow = new WritePrescription(SelectedAppointment, app.LanguageCode);
                    prescriptionWindow.Show();
                }
                else
                {
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("Appointment has not started.");
                    }
                    else
                    {
                        MessageBox.Show("Termin jos nije poceo.");
                    }
                }
            }
        }

        private void cldSample_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeAppointmentsList();
            //CustomerGrid.ItemsSource = appointments;
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

        private void sendReport_Click(object sender, RoutedEventArgs e)
        {
            Appointment SelectedAppointment = (Appointment)CustomerGrid.SelectedItem;
            if (SelectedAppointment != null)
            {

                if (DateUtils.DateTimeStarted(SelectedAppointment.StartTime))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF file|*.pdf";
                    saveFileDialog.ValidateNames = true;
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                        try
                        {
                            PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                            doc.Open();

                            //doc.Add(new iTextSharp.text.Font())
                            doc.Add(new iTextSharp.text.Header("PDF REPORT", "pdf report"));
                            doc.Add(new iTextSharp.text.Paragraph("Reports:"));
                            List<Report> reports = ReportController.ReadByAppointmentId(SelectedAppointment.Id);
                            if (reports.Count == 0)
                            {
                                doc.Add(new iTextSharp.text.Paragraph("   ---"));

                            }
                            else
                            {
                                foreach (Report report in reports)
                                {
                                    doc.Add(new iTextSharp.text.Paragraph("   " + report.Content));
                                }
                            }


                            doc.Add(Chunk.NEWLINE);
                            doc.Add(new iTextSharp.text.Paragraph("Prescriptions:"));
                            List<Prescription> prescriptions = PrescriptionController.ReadByAppointmentId(SelectedAppointment.Id);
                            if (prescriptions.Count == 0)
                            {
                                doc.Add(new iTextSharp.text.Paragraph("   ---"));
                            }
                            else
                            {
                                foreach (Prescription prescription in prescriptions)
                                {
                                    doc.Add(new iTextSharp.text.Paragraph("   Medicine name: " + prescription.Medicine));
                                    doc.Add(new iTextSharp.text.Paragraph("   Take medicine " + prescription.TimesADay.ToString() + " times a day"));
                                    doc.Add(new iTextSharp.text.Paragraph("   Prescription starts on:  " + prescription.StartDate.ToString("dd/MM/yyyy")));
                                    doc.Add(new iTextSharp.text.Paragraph("   Prescription ends on:  " + prescription.EndDate.ToString("dd/MM/yyyy")));
                                    doc.Add(Chunk.NEWLINE);
                                }
                            }
                        }
                        catch
                        {

                        }
                        finally
                        {
                            doc.Close();
                        }
                    }
                }
                else
                {
                    var app = App.Current as App;
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("Appointment has not started.");
                    }
                    else
                    {
                        MessageBox.Show("Termin jos nije poceo.");
                    }
                }
            }
        }
    }
}
