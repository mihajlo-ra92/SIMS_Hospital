using Controller;
using Dto;
using Exception;
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
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoggedInController loggedInController;
        private MaliciouslyPatientController MaliciouslyPatientController;
        private UserController userController;
        private UserNotificationController userNotificationController;

        public MainWindow()
        {
            InitializeComponent();

            InitializeController();
        }

        private void InitializeController()
        {
            var app = Application.Current as App;
            MaliciouslyPatientController = app.MaliciouslyPatientController;
            loggedInController = app.LoggedInController;
            userController = app.UserController;
            userNotificationController = app.UserNotificationController;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            UserLoginDTO userLogin = new UserLoginDTO()
            {
                Username = usernameText.Text,
                Password = passwordText.Password,
            };

            User user = GetUser(userLogin);

            if (user != null)
            {
                List<UserNotification> userNotifications = userNotificationController.ReadByUserId(user.Id);
                foreach (UserNotification notification in userNotifications)
                {
                    MessageBox.Show(notification.Description);
                }

                userNotificationController.DeleteUserNotifications(user.Id);

                var app = Application.Current as App;
                app.User = user;
                RoleHomePage(user);
            }
        }

        private User GetUser(UserLoginDTO userLogin)
        {
            User user = null;
            try
            {
                loggedInController.Create(userLogin);
                user = userController.ReadByUsername(userLogin.Username);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == "Username")
                {
                    var app = Application.Current as App;
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("User doesn't exist");
                    }
                    else
                    {
                        MessageBox.Show("Korisnik ne postoji!");
                    }
                }
                else if (ex.Message == "Password")
                {
                    var app = Application.Current as App;
                    if (app.LanguageCode == "en")
                    {
                        MessageBox.Show("Incorrect password!");
                    }
                    else
                    {
                        MessageBox.Show("Pogresna lozinka!");
                    }
                }
                else if (ex.Message == "Already Logged In")
                {
                    //var app = Application.Current as App;
                    //if (app.LanguageCode == "en")
                    //{
                    //    MessageBox.Show("User is already logged in.");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Korisnik je vec ulogovan.");
                    //}
                    user = userController.ReadByUsername(userLogin.Username);
                }
            }
            return user;
        }

        private void RoleHomePage(User user)
        {
            if (user.Role == "Patient")
            {
                if (MaliciouslyPatientController.IsPatientMaliciously(user.Id))
                {
                    MessageBox.Show("Maliciozni korisnik!");
                }
                else
                {
                    PatientHomePage patientDialog = new PatientHomePage(user);
                    patientDialog.Show();
                    this.Close();
                }
            }
            else if (user.Role == "Doctor")
            {
                DoctorHomePage doctorHomePage = new DoctorHomePage(user);
                doctorHomePage.Show();
                this.Close();
            }
            else if (user.Role == "Secretary")
            {
                SecretaryHomePage secretaryHomePage = new SecretaryHomePage(user);
                secretaryHomePage.Show();
                this.Close();
            }
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
            app.LanguageCode = languageCode;
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
            app.ThemeCode= themeCode;
        }
    }
}
