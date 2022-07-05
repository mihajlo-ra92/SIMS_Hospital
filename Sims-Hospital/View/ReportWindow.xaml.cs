using Controller;
using Dto;
using Model;
using Sims_Hospital.Utils;
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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public Report Report { get; set; }
        public Appointment Appointment;
        private readonly ReportController ReportController;
        private readonly AppointmentController AppointmentController;
        public ReportWindow(Appointment appointment, string languageCode)
        {
            InitializeComponent();
            this.Appointment = appointment;
            var app = Application.Current as App;
            this.ReportController = app.ReportController;
            this.AppointmentController = app.AppointmentController;
            this.Report = new Report();
            this.Report.Appointment = this.Appointment;
            SwitchLanguage(languageCode);
            InitializeFields();
        }
        private void InitializeFields()
        {
            if (this.Report.Content == null)
            {
                contentText.Text = "";
            }
            else
            {
                contentText.Text = Report.Content.ToString();
            }
        }

        private void writePrescription_Click(object sender, RoutedEventArgs e)
        {
            if (DateUtils.DateTimeStarted(Appointment.StartTime))
            {
                var app = App.Current as App;
                WritePrescription prescriptionWindow = new WritePrescription(Appointment, app.LanguageCode);
                prescriptionWindow.Show();
            }
            else
            {
                MessageBox.Show("Termin jos nije poceo.");
            }
        }

        private void saveReportButton_Click(object sender, RoutedEventArgs e)
        {
            this.Report.Content = contentText.Text;
            CreateReportDTO createReport = new CreateReportDTO();
            createReport.Appointment = this.Appointment;
            createReport.Content = this.Report.Content;
            this.ReportController.Create(createReport);
            this.Close();
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
    }
}
