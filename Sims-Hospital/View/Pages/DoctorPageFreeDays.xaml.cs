using Controller;
using Model;
using Dto;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sims_Hospital.Utils;
using System.ComponentModel;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for DoctorPageFreeDays.xaml
    /// </summary>
    public partial class DoctorPageFreeDays : Page
    {
        public FreeDayController FreeDayControler;
        public DoctorController DoctorController;
        public AppointmentController AppointmentController;
        private static DoctorPageFreeDays instance = null;
        public static DoctorPageFreeDays Instance(Doctor Doctor, string languageCode)
        {
            if (instance == null)
            {
                instance = new DoctorPageFreeDays(Doctor, languageCode);
            }
            return instance;
        }
        public Doctor Doctor { get; set; }

        public BindingList<FreeDay> freeDays;
        public DoctorPageFreeDays(Doctor doctor, string languageCode)
        {
            InitializeComponent();
            this.DataContext = this;
            InitializeFields(doctor);
            SwitchLanguage(languageCode);
            InitializeDataGrid();
        }
        private void InitializeDataGrid()
        {
            List<FreeDay> allFreeDays = FreeDayControler.ReadByDoctorId(Doctor.Id);
            freeDays = new BindingList<FreeDay>(allFreeDays);
            FreeDayGrid.ItemsSource = freeDays;
        }
        private void InitializeFields(Doctor doctor)
        {
            var app = Application.Current as App;
            FreeDayControler = app.FreeDayController;
            DoctorController = app.DoctorController;
            AppointmentController = app.AppointmentController;
            this.Doctor = doctor;

        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            //needs to check if end date is before start date
            if ((bool)isEmergency.IsChecked)
            {
                BookFreeDay();
                InitializeDataGrid();
            }
            else if (!DateUtils.DateIsAfterTwoDays((DateTime)datePickerStart.SelectedDate))
            {
                var app = App.Current as App;
                if (app.LanguageCode == "en")
                {
                    MessageBox.Show("If it is not an emergency, a free day can " +
                    "only begin atleast two days after the day of request.");
                }
                else
                {
                    MessageBox.Show("Ako nije hitan slucaj, slobodan dan moze " +
                    "da pocne najmanje dva dana nakon zahteva.");
                }

            }
            else
            {

                if (AppointmentController.DoctorHasAppointment(Doctor,
                    (DateTime)datePickerStart.SelectedDate,
                    (DateTime)datePickerEnd.SelectedDate))
                {
                    var app = App.Current as App;
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("You have booked appointments at the time" +
                        "of selected free days, but your request is not an emergency.");
                    }
                    else
                    {
                        MessageBox.Show("Imate zakazane termine za vreme izabranih" +
                        "slobodnih dana, a zahtev nije hitan.");
                    }

                }
                else if (FreeDayControler.SameSpecialisationsHaveFreeDay(Doctor,
                    (DateTime)datePickerStart.SelectedDate,
                    (DateTime)datePickerEnd.SelectedDate))
                {
                    var app = App.Current as App;
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("Multiple colleagues if your specialisation are on vacation " +
                        "during selected free days, but your request is not an emergency");
                    }
                    else
                    {
                        MessageBox.Show("Mnozina kolega iste specijalizacije je na raspustu" +
                        "u izabranom raspone, a zahtev nije hitan.");
                    }

                }
                else
                {
                    BookFreeDay();
                    InitializeDataGrid();
                }
            }
        }
        private CreateFreeDayDTO CreateAndFillDTO()
        {
            CreateFreeDayDTO NewFreeDay = new CreateFreeDayDTO();
            NewFreeDay.StartDate = (DateTime)datePickerStart.SelectedDate;
            NewFreeDay.EndDate = (DateTime)datePickerEnd.SelectedDate;
            NewFreeDay.Note = requestNote.Text;
            NewFreeDay.IsEmergency = (bool)isEmergency.IsChecked;
            NewFreeDay.Doctor = DoctorController.ReadById(Doctor.Id);
            NewFreeDay.RequestState = RequestStateType.Waiting;
            return NewFreeDay;

        }

        private void ResetFields()
        {
            datePickerStart.Text = "";
            datePickerEnd.Text = "";
            requestNote.Text = "";
            isEmergency.IsChecked = false;
            selectedFreeDayNote.Text = "";
            selectedFreeDayDecisionNote.Text = "";
        }

        private void BookFreeDay()
        {
            CreateFreeDayDTO NewFreeDay = CreateAndFillDTO();
            FreeDayControler.Create(NewFreeDay);
            var app = App.Current as App;
            if (app.LanguageCode == "en")
            {
                MessageBox.Show("Request sent successfully!");
            }
            else
            {
                MessageBox.Show("Uspesno poslat zahtev!");
            }
            ResetFields();
        }

        private void FreeDayGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadNotes();
        }
        private void LoadNotes()
        {
            FreeDay SelectedFreeDay = (FreeDay)FreeDayGrid.SelectedItem;
            if (SelectedFreeDay != null)
            {
                selectedFreeDayNote.Text = SelectedFreeDay.Note;
                selectedFreeDayDecisionNote.Text = SelectedFreeDay.DecisionNote;
            }
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
