using Controller;
using Dto;
using Model;
using Sims_Hospital.View.Pages;
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
    public partial class DoctorHomePage : Window
    {
        public AppointmentController AppointmentController;
        public DoctorController DoctorController;
        public MedicalRecordController MedicalRecordController;
        public GuestMedicalRecordController GuestMedicalRecordController;
        public BindingList<Appointment> appointments;
        private LoggedInController LoggedInController;
        public Doctor Doctor { get; set; }
        public DoctorHomePage(User User)
        {
            InitializeComponent();
            InitializeFields(User);
        }
        private void InitializeFields(User User)
        {
            var app = Application.Current as App;
            AppointmentController = app.AppointmentController;
            DoctorController = app.DoctorController;
            MedicalRecordController = app.MedicalRecordController;
            GuestMedicalRecordController = app.GuestMedicalRecordController;
            Doctor = DoctorController.ReadById(User.Id);
            LoggedInController = app.LoggedInController;
            Main.Content = DoctorPageHome.Instance(app.User, app.LanguageCode);
            //Main.Content = DoctorPageMedicineListMVVM.Instance(this.Doctor, app.LanguageCode);
            if (app.LanguageCode == "en")
            {
                LanguageComboBox.SelectedIndex = 0;
            }
            else
            {
                LanguageComboBox.SelectedIndex = 1;
            }
            if (app.ThemeCode == "light")
            {
                ThemeComboBox.SelectedIndex = 0;
            }
            else
            {
                ThemeComboBox.SelectedIndex = 1;
            }
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            Main.Content = DoctorPageHome.Instance(app.User, app.LanguageCode);
        }

        private void CreateAppointment_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            Main.Content = DoctorPageCreateAppointment.Instance(this.Doctor, app.LanguageCode);
        }

        private void MedicineList_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            Main.Content = DoctorPageMedicineList.Instance(app.User, app.LanguageCode);
        }
        private void FreeDays_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            Main.Content = DoctorPageFreeDays.Instance(this.Doctor, app.LanguageCode);
        }

        private void ReferPatient_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            Main.Content = DoctorPageReferPatient.Instance(this.Doctor, app.LanguageCode);
        }

        private void MeidcalRecord_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            Main.Content = new DoctorPageViewMedicalRecord(app.LanguageCode);
            //Main.Content = new DoctorPageViewMedicalRecordMVVM(app.LanguageCode);
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            Main.Content = DoctorPageAccount.Instance(app.User, app.LanguageCode);
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedIndex == 0)
            {
                SwitchLanguage("en");
            }
            else
            {
                SwitchLanguage("sr");
            }
        }
        private void SwitchLanguage(string languageCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            var app = Application.Current as App;
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
            app.LanguageCode = languageCode;
            if (Main != null)
            {
                string pageName = "";
                if (Main.Content != null)
                {
                    pageName = Main.Content.ToString();
                }
                switch (pageName)
                {
                    case "Sims_Hospital.View.DoctorPageHome":
                        DoctorPageHome.Instance(app.User, app.LanguageCode).SwitchLanguage(app.LanguageCode);
                        break;
                    case "Sims_Hospital.View.Pages.DoctorPageAccount":
                        DoctorPageAccount.Instance(app.User, app.LanguageCode).SwitchLanguage(app.LanguageCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageCreateAppointment":
                        DoctorPageCreateAppointment.Instance(this.Doctor, app.LanguageCode).SwitchLanguage(app.LanguageCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageFreeDays":
                        DoctorPageFreeDays.Instance(this.Doctor, app.LanguageCode).SwitchLanguage(app.LanguageCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageMedicineList":
                        DoctorPageMedicineList.Instance(app.User, app.LanguageCode).SwitchLanguage(app.LanguageCode);
                        DoctorPageMedicineListMVVM.Instance(app.User, app.LanguageCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageReferPatient":
                        DoctorPageReferPatient.Instance(this.Doctor, app.LanguageCode).SwitchLanguage(app.LanguageCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageViewMedicalRecord":
                        DoctorPageViewMedicalRecord.Instance(app.LanguageCode).SwitchLanguage(app.LanguageCode);
                        DoctorPageViewMedicalRecordMVVM.Instance(app.LanguageCode);
                        break;
                    default:
                        //
                        break;
                }
            }
            else
            {
                //Main.Content = new DoctorHomePage(Doctor, languageCode);
            }
        }

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeComboBox.SelectedIndex == 0)
            {
                SwitchTheme("light");
            }
            else
            {
                SwitchTheme("dark");
            }
        }

        private void SwitchTheme(string themeCode)
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
            app.ThemeCode = themeCode;
            if (Main != null)
            {
                string pageName = "";
                if (Main.Content != null)
                {
                    pageName = Main.Content.ToString();
                }
                switch (pageName)
                {
                    case "Sims_Hospital.View.DoctorPageHome":
                        //Main.Content = new DoctorPageHome(Doctor, languageCode);
                        DoctorPageHome.Instance(app.User, app.LanguageCode).SwitchTheme(app.ThemeCode);
                        break;
                    case "Sims_Hospital.View.Pages.DoctorPageAccount":
                        DoctorPageAccount.Instance(app.User, app.LanguageCode).SwitchTheme(app.ThemeCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageCreateAppointment":
                        DoctorPageCreateAppointment.Instance(this.Doctor, app.LanguageCode).SwitchTheme(app.ThemeCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageFreeDays":
                        DoctorPageFreeDays.Instance(this.Doctor, app.LanguageCode).SwitchTheme(app.ThemeCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageMedicineList":
                        DoctorPageMedicineList.Instance(app.User, app.LanguageCode).SwitchTheme(app.ThemeCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageReferPatient":
                        DoctorPageReferPatient.Instance(this.Doctor, app.LanguageCode).SwitchTheme(app.ThemeCode);
                        break;
                    case "Sims_Hospital.View.DoctorPageViewMedicalRecord":
                        DoctorPageViewMedicalRecord.Instance(app.LanguageCode).SwitchTheme(app.ThemeCode);
                        break;
                    default:
                        //
                        break;
                }
            }
            else
            {
                //Main.Content = new DoctorHomePage(Doctor, languageCode);
            }
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            LoggedInController.Delete(Doctor.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
