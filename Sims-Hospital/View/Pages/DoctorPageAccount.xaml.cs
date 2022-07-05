using Controller;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sims_Hospital.View.Pages
{
    /// <summary>
    /// Interaction logic for DoctorPageAccount.xaml
    /// </summary>
    public partial class DoctorPageAccount : Page
    {
        private DoctorController DoctorController;
        private LoggedInController LoggedInController;
        public List<string> SexTypeCollection { get; set; }
        private Doctor Doctor { get; set; }
        private bool isEditable = false;
        private bool seePassword = false;
        private static DoctorPageAccount instance = null;

        public static DoctorPageAccount Instance(User User, string languageCode)
        {
            if (instance == null)
            {
                instance = new DoctorPageAccount(User, languageCode);
            }
            return instance;
        }

        public DoctorPageAccount(User User, string languageCode)
        {
            InitializeComponent();
            InitializeFields(User);
            SwitchLanguage(languageCode);
            SexTypeComboBoxInitialization();
            InitializeTextBlocks();
            InitializeTextBoxes();
            UpdateVisibility();
        }
        private void SexTypeComboBoxInitialization()
        {
            SexTypeCollection = new List<string>()
                {
                    "Muski",
                    "Zenski"
                };
            DataContext = this;
            sexTypeComboBox.SelectedIndex = 0;
        }
        private void UpdateVisibility()
        {
            if (isEditable)
            {
                UpdateVisibilityIsEditable();
            }
            else
            {
                UpdateVisibilityIsNotEditable();
            }
        }
        private void UpdateVisibilityIsEditable()
        {
            seePassword = false;
            UsernameBlock.Visibility = Visibility.Hidden;
            PasswordBlock.Visibility = Visibility.Hidden;
            EmailBlock.Visibility = Visibility.Hidden;
            FirstNameBlock.Visibility = Visibility.Hidden;
            LastNameBlock.Visibility = Visibility.Hidden;
            FirstNameBlock.Visibility = Visibility.Hidden;
            BrithDateBlock.Visibility = Visibility.Hidden;
            GenderBlock.Visibility = Visibility.Hidden;

            UsernameBox.Visibility = Visibility.Visible;
            InitCantSeePassword();
            EmailBox.Visibility = Visibility.Visible;
            FirstNameBox.Visibility = Visibility.Visible;
            LastNameBox.Visibility = Visibility.Visible;
            showPassword.Visibility = Visibility.Visible;
            datePickerBirth.Visibility = Visibility.Visible;
            sexTypeComboBox.Visibility = Visibility.Visible;
        }
        private void UpdateVisibilityIsNotEditable()
        {
            seePassword = false;
            UsernameBlock.Visibility = Visibility.Visible;
            PasswordBlock.Visibility = Visibility.Visible;
            EmailBlock.Visibility = Visibility.Visible;
            FirstNameBlock.Visibility = Visibility.Visible;
            LastNameBlock.Visibility = Visibility.Visible;
            FirstNameBlock.Visibility = Visibility.Visible;
            BrithDateBlock.Visibility = Visibility.Visible;
            GenderBlock.Visibility = Visibility.Visible;

            UsernameBox.Visibility = Visibility.Hidden;
            PasswordBox.Visibility = Visibility.Hidden;
            PasswordTextBox.Visibility = Visibility.Hidden;
            EmailBox.Visibility = Visibility.Hidden;
            FirstNameBox.Visibility = Visibility.Hidden;
            LastNameBox.Visibility = Visibility.Hidden;
            showPassword.Visibility = Visibility.Hidden;
            datePickerBirth.Visibility = Visibility.Hidden;
            sexTypeComboBox.Visibility = Visibility.Hidden;
        }

        private void InitializeFields(User User)
        {
            var app = Application.Current as App;
            DoctorController = app.DoctorController;
            LoggedInController = app.LoggedInController;
            Doctor = DoctorController.ReadById(User.Id);
        }
        private void InitializeTextBlocks()
        {
            UsernameBlock.Text = Doctor.Username;
            PasswordBlock.Text = "???";
            EmailBlock.Text = Doctor.Email;
            FirstNameBlock.Text = Doctor.Name;
            LastNameBlock.Text = Doctor.LastName;
            BrithDateBlock.Text = Doctor.BirthDate.ToString("dd/MM/yyyy");
            GenderBlock.Text = UserUtils.PrintGenderSRB(Doctor.Gender);

        }

        private void InitializeTextBoxes()
        {
            UsernameBox.Text = Doctor.Username;
            PasswordTextBox.Text = Doctor.Password;
            EmailBox.Text = Doctor.Email;
            FirstNameBox.Text = Doctor.Name;
            LastNameBox.Text = Doctor.LastName;
            datePickerBirth.Text = Doctor.BirthDate.ToString("dd/MM/yyyy");
            //BrithDateBlock.Text = Doctor.BirthDate.ToString("dd/MM/yyyy");
            //GenderBlock.Text = UserUtils.PrintGenderSRB(Doctor.Gender);
        }
        private void editAccount_Click(object sender, RoutedEventArgs e)
        {
            if (isEditable)
            {
                var app = App.Current as App;
                if (app.LanguageCode == "en")
                {
                    if (MessageBox.Show("Are you sure?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        isEditable = !isEditable;
                        UpdateVisibility();
                        InitializeTextBlocks();
                    }
                }
                else
                {
                    if (MessageBox.Show("Da li ste sigurni?", "Pažnja", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        isEditable = !isEditable;
                        UpdateVisibility();
                        InitializeTextBlocks();
                    }
                }
                
            }
            else
            {
                isEditable = !isEditable;
                UpdateVisibility();
                InitializeTextBoxes();
            }

        }

        private void showPassword_Click(object sender, RoutedEventArgs e)
        {
            seePassword = !seePassword;
            if (seePassword)
            {
                InitCanSeePassword();
            }
            else
            {
                InitCantSeePassword();
            }
        }
        private void InitCanSeePassword()
        {
            showPasswordIcon.Source = new BitmapImage(new Uri(@"/Resources/Images/hide_view.png", UriKind.Relative));
            PasswordTextBox.Visibility = Visibility.Visible;
            if (PasswordTextBox.Text == "")
            {
                PasswordTextBox.Text = Doctor.Password;
            }
            PasswordBox.Visibility = Visibility.Hidden;
        }
        private void InitCantSeePassword()
        {
            showPasswordIcon.Source = new BitmapImage(new Uri(@"/Resources/Images/view.png", UriKind.Relative));
            PasswordBox.Visibility = Visibility.Visible;
            if (PasswordBox.Password == "")
            {
                PasswordBox.Password = Doctor.Password;
            }
            PasswordTextBox.Visibility = Visibility.Hidden;
        }
        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            LoggedInController.Delete(Doctor.Id);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //treba nekako da zatvorimo DoctorHomePage
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (seePassword)
            {
                PasswordBox.Password = PasswordTextBox.Text;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!seePassword)
            {
                PasswordTextBox.Text = PasswordBox.Password;
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
