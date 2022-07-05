using Controller;
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
    /// Interaction logic for DoctorViewGuestMedicalRecord.xaml
    /// </summary>
    public partial class DoctorViewGuestMedicalRecord : Window
    {
        public GuestMedicalRecord guestmedicalRecord;
        private readonly GuestMedicalRecordController guestmedicalRecordController;
        private AllergiesController AllergiesController;
        public DoctorViewGuestMedicalRecord(GuestMedicalRecord guestmedicalRecord)
        {
            InitializeComponent();
            this.guestmedicalRecord = guestmedicalRecord;
            InitializeFields();
            var app = Application.Current as App;
            this.guestmedicalRecordController = app.GuestMedicalRecordController;
            this.AllergiesController = app.AllergiesController;
            //guestmedicalRecord.Allergies = 
            //var alergeni = new List<string>();
            //alergeni.Add("alergen1");
            //alergeni.Add("alergen2");

            //allergensList.ItemsSource = alergeni;

            allergensList.ItemsSource = this.guestmedicalRecord.Allergies.Allergens;
            allergicMedicinesList.ItemsSource = AllergiesController.ReadAllergicMedicineNamesById(this.guestmedicalRecord.Patient.Id);
        }
        private void InitializeFields()
        {
            nameText.Text = guestmedicalRecord.Patient.NameLastName;
            umcnText.Text = guestmedicalRecord.Umcn;
            bloodTypeText.Text = guestmedicalRecord.BloodType.ToString();

        }
        private void savePatientButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
