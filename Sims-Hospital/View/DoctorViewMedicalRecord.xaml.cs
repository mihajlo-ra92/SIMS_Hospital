using System;
using Model;
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
using Controller;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for DoctorViewMedicalRecord.xaml
    /// </summary>
    public partial class DoctorViewMedicalRecord : Window
    {
        public Model.MedicalRecord MedicalRecord;
        private readonly MedicalRecordController MedicalRecordController;
        private AllergiesController AllergiesController;
        public DoctorViewMedicalRecord(Model.MedicalRecord medicalRecord)
        {
            InitializeComponent();
            this.MedicalRecord = medicalRecord;
            InitializeFields();
            var app = Application.Current as App;
            this.MedicalRecordController = app.MedicalRecordController;
            this.AllergiesController = app.AllergiesController;
            allergensList.ItemsSource = this.MedicalRecord.Allergies.Allergens;
            allergicMedicinesList.ItemsSource = AllergiesController.ReadAllergicMedicineNamesById(this.MedicalRecord.Patient.Id);
        }
        private void InitializeFields()
        {
            nameText.Text = MedicalRecord.Patient.NameLastName;
            umcnText.Text = MedicalRecord.Umcn;
            parentNameText.Text = MedicalRecord.ParentName;
            bloodTypeText.Text = MedicalRecord.BloodType.ToString();
            addressText.Text = MedicalRecord.Address.ToString();

        }
        private void addAllergiesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void savePatientButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
